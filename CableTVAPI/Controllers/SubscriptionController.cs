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
    public class SubscriptionController : ControllerBase
    {
        private readonly ICableService _cableService;
        public SubscriptionController(ICableService cableService)
        {
            _cableService = cableService;
        }
        [HttpGet("{provider_id}")]
        public async Task<ActionResult<List<CableEntityAPI>>> GetAllSubscription(int provider_id)
        {
            return await _cableService.GetAllSubscription(provider_id);
        }
    }
}
