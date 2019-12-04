using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EvxWebAppCore.Common;
using EvxWebAppCore.Common.Interfaces;
using EvxWebAppCore.Models;
using EvxWebAppCore.ViewModel;
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
                UserDetailModel user = HttpContext.Session.SessionGet<UserDetailModel>("user");
                if (user == null)
                    return PartialView("_ErrorPartial", new ErrorViewModel
                    {
                        ErrorMessage = "Session expired. Please login to continue.",
                        ErrorCode = 1
                    });
                if (AdminID == 0)
                    return PartialView("_ErrorPartial", new ErrorViewModel
                    {
                        ErrorMessage = "Admin ID is required!",
                        ErrorCode = 3
                    });
                return PartialView("DriversPartial", await _driverRepository.GetDrivers(AdminID));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }


    }
}
