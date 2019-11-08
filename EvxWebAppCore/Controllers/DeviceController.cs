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
    public class DeviceController: Controller
    {
        private readonly IDevice _deviceRepository;
        public DeviceController(IDevice deviceRepository)
        {
            _deviceRepository = deviceRepository;
        }
        [HttpGet("GetDevices")]
        public async Task<IActionResult> GetDevices()
        {
            try
            {
                return Ok(await _deviceRepository.GetDevices());
            }catch(Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [HttpGet("ViewDevices")]
        public async Task<IActionResult> ViewDevices()
        {
            try
            {
                return PartialView("DevicesPartial", await _deviceRepository.GetDevices());
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
