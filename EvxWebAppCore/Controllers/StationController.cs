using EvxWebAppCore.Common;
using EvxWebAppCore.Common.Interfaces;
using EvxWebAppCore.Models;
using EvxWebAppCore.ViewModel;
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
                UserDetailModel user = HttpContext.Session.SessionGet<UserDetailModel>("user");
                if (user == null)
                    return PartialView("_ErrorPartial", new ErrorViewModel
                    {
                        ErrorMessage = "Session expired. Please login to continue.",
                        ErrorCode = 1
                    });
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
            UserDetailModel user = HttpContext.Session.SessionGet<UserDetailModel>("user");
            if (user == null)
                return PartialView("_ErrorPartial", new ErrorViewModel
                {
                    ErrorMessage = "Session expired. Please login to continue.",
                    ErrorCode = 1
                });
            return PartialView(station);
        }

        [HttpPost("UpdateStation")]
        public async Task<IActionResult> UpdateStation(int id, 
            string name, 
            double lat, double lng,
            int tblRouteID,
            string direction,
            int isMainterminal)
        {
            try
            {
                return Ok(await _stationRepository.UpdateStation(id, name, lat, lng, tblRouteID, direction, isMainterminal));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }
        [HttpPost("AddStation")]
        public async Task<IActionResult> AddStation(string value, 
            double lat, double lng, 
            int tblRouteID, 
            string direction, 
            int isMainterminal)
        {
            try
            {
                return Ok(await _stationRepository.AddStation(value, lat, lng, tblRouteID, direction, isMainterminal));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }
        [HttpGet("DeleteStation")]
        public async Task<IActionResult> DeleteStation(int destinationid)
        {
            try
            {
                return Ok(await _stationRepository.DeleteStation(destinationid));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }
    }
}
