using EvxWebAppCore.Common.Interfaces;
using EvxWebAppCore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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

        public async Task<IActionResult> Index()
        {
            return PartialView(await _deviceRepository.GetDevices());
        }
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

        [Route("GPSFormPartial")]
        [HttpPost]
        public IActionResult GPSFormPartial([FromBody]DeviceModel device)
        {
            device.Model = device.Model ?? "";
            device.networkList = new List<SelectListItem>();
            device.networkList.Add(new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem("Globe", "Globe",
                device.Model.Equals("Globe", StringComparison.OrdinalIgnoreCase) ? true : false));

            device.networkList.Add(new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem("Smart", "Smart",
                device.Model.Equals("Smart", StringComparison.OrdinalIgnoreCase) ? true : false));

            return PartialView(device); 
        }

    }
}
