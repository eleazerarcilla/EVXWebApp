using EvxWebAppCore.Common.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EvxWebAppCore.Controllers
{
    [Route("api/[controller]")]
    public class DestinationController: Controller
    {
        private readonly IDestination _destinationRepository;
        public DestinationController(IDestination destinationRepository)
        {
            _destinationRepository = destinationRepository;
        }
        [HttpGet("GetDestinations")]
        public async Task<IActionResult> GetDestinations(int RouteID = 0)
        {
            try
            {
                return Ok(await _destinationRepository.GetDestinations(RouteID));
            }catch(Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
