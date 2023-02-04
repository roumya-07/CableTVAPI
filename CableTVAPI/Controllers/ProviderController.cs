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
    public class ProviderController : ControllerBase
    {
        private readonly ICableService _cableService;
        public ProviderController(ICableService cableService)
        {
            _cableService = cableService;
        }
        [HttpGet]
        public async Task<ActionResult<List<CableEntityAPI>>> GetAllProvider()
        {
            return await _cableService.GetAllProvider();
        }
    }
}
