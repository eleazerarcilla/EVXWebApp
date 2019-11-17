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
    public class RouteController : Controller
    {
        private readonly IRoute _routeRepository;
        public RouteController(IRoute routeRepository)
        {
            _routeRepository = routeRepository;
        }

        [HttpGet("ViewRoutes")]
        public async Task<IActionResult> ViewRoutes(int LineID = 0)
        {
           
                return PartialView("RoutesPartial", await _routeRepository.GetRoute(LineID));
            

        }
        [Route("RouteFormPartial")]
        [HttpPost]
        public async Task<IActionResult> RouteFormPartial([FromBody]RouteModel route)
        {
            return PartialView(route);
        }

        [HttpPost("UpdateRoute")]
        public async Task<IActionResult> UpdateRoute(int routeID, string newRouteName)
        {
            try
            {
                return Ok(await _routeRepository.UpdateRoute(routeID,newRouteName));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }
        [HttpPost("AddRoute")]
        public async Task<IActionResult> AddRoute(int lineID, string routeName)
        {
            try
            {
                return Ok(await _routeRepository.AddRoute(lineID, routeName));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }
        [HttpGet("DeleteRoute")]
        public async Task<IActionResult> DeleteRoute(int routeID)
        {
            try
            {
                return Ok(await _routeRepository.DeleteRoute(routeID));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }
    }
}
