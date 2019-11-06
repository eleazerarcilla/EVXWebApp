using EvxWebAppCore.Common.Interfaces;
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

        [HttpGet("GetRoutes")]
        public async Task<IActionResult> GetRoutes()
        {
            return Json(await _routeRepository.GetRoute());
        }
    }
}
