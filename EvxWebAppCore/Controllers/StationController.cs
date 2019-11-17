using EvxWebAppCore.Common.Interfaces;
using EvxWebAppCore.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EvxWebAppCore.Controllers
{
    [Route("api/[controller]")]
    public class StationController : Controller
    {
        private readonly IStation _stationRepository;
        public StationController(IStation stationRepository)
        {
            _stationRepository = stationRepository;
        }
        [HttpGet("GetStations")]
        public async Task<IActionResult> GetStations(int RouteID = 0)
        {
            try
            {
                return Ok(await _stationRepository.GetStations(RouteID));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [HttpGet("ViewStations/{RouteID}")]
        public async Task<IActionResult> ViewStations(int RouteID = 0)
        {
            try
            {
                return PartialView("StationsPartial", await _stationRepository.GetStations(RouteID));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [Route("StationFormPartial")]
        [HttpPost]
        public IActionResult StationFormPartial([FromBody]StationModel station)
        {
            return PartialView(station);
        }
    }
}
