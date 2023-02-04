using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CableTVAPI.Models;
using CableTVAPI.Services;

namespace CableTVAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CableController : ControllerBase
    {
        private readonly ICableService _cableService;
        public CableController(ICableService cableService)
        {
            _cableService = cableService;
        }

        [HttpGet]
        public async Task<ActionResult<List<CableEntityAPI>>> ViewAll()
        {
            return await _cableService.ViewAll();
        }

        [HttpGet("{registration_id}")]
        public async Task<ActionResult<List<CableEntityAPI>>> ViewOne(int registration_id)
        {
            return await _cableService.ViewOne(registration_id);
        }

        [HttpPut("{registration_id}")]
        public async Task<ActionResult<CableEntityAPI>> InsertOrUpdate(int registration_id, CableEntityAPI CE)
        {
            if (registration_id != CE.registration_id)
            {
                return BadRequest();
            }
            try
            {
                await _cableService.InsertOrUpdate(CE);

                return CreatedAtAction("ViewAll", new { id = CE.registration_id }, CE);
            }

            catch (Exception ex)
            {
                if (ViewOne(registration_id) == null)
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
        }
    }
}
