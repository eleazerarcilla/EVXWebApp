using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EvxWebAppCore.Common.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EvxWebAppCore.Controllers
{
    [Route("api/[controller]")]
    public class DriverController : Controller
    {
        private readonly IDriver _driverRepository;
        public DriverController(IDriver driverRepository)
        {
            _driverRepository = driverRepository;
        }
        [HttpGet("GetDrivers/{AdminID}")]
        public async Task<IActionResult> GetDrivers(int AdminID = 0)
        {
            try
            {
                if (AdminID == 0)
                    return BadRequest("Admin ID is required!");
                return Ok(await _driverRepository.GetDrivers(AdminID));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [HttpGet("ViewDrivers/{AdminID}")]
        public async Task<IActionResult> ViewDrivers(int AdminID = 0)
        {
            try
            {
                if (AdminID == 0)
                    return BadRequest("Admin ID is required!");
                return PartialView("DriversPartial", await _driverRepository.GetDrivers(AdminID));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
