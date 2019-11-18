using EvxWebAppCore.Common;
using EvxWebAppCore.Common.Interfaces;
using EvxWebAppCore.Models;
using EvxWebAppCore.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EvxWebAppCore.Controllers
{
    [Route("api/[controller]")]
    public class DeviceController : Controller
    {
        private readonly IDevice _deviceRepository;
        private readonly ILine _lineRepository;
        private readonly IDriver _driverRepository;

        public DeviceController(IDevice deviceRepository, ILine lineRepository, IDriver driverRepository)
        {
            _deviceRepository = deviceRepository;
            _lineRepository = lineRepository;
            _driverRepository = driverRepository;
        }
        public async Task<IActionResult> Index()
        {
            return PartialView(await _deviceRepository.GetDevices());
        }

        [HttpGet("GetDevices")]
        public async Task<IActionResult> GetDevices()
        {
            try
            {
                return Ok(await _deviceRepository.GetDevices());
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [Route("GPSFormPartial")]
        [HttpPost]
        public async Task<IActionResult> GPSFormPartial([FromBody]DeviceModel device)
        {
            try
            {
                GPSDeviceViewModel GPSViewModel = new GPSDeviceViewModel(device);
                GPSViewModel.Lines.AddRange(GlobalHelpers.GenerateSelectListForLines(await _lineRepository.GetLines(HttpContext.Session.SessionGet<UserDetailModel>("user").ID), GPSViewModel.DevicePHP));
                GPSViewModel.Drivers.AddRange(GlobalHelpers.GenerateSelectListForDrivers(await _driverRepository.GetDrivers(HttpContext.Session.SessionGet<UserDetailModel>("user").ID)));
                return PartialView(GPSViewModel);
            }
            catch (Exception ex) { return BadRequest(ex); }

        }
        [Route("AddDevice")]
        [HttpPost]
        public async Task<IActionResult> AddDevice([FromBody] DeviceModelPHP device)
        {
            try
            {
                return Ok(await _deviceRepository.AddDevice(device));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [Route("UpdateDevice")]
        [HttpPost]
        public async Task<IActionResult> UpdateDevice([FromBody] DeviceModelPHP device)
        {
            try
            {
                return Ok(await _deviceRepository.UpdateDevice(device));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [HttpGet("DeleteDevice/{deviceId}")]
        public async Task<IActionResult> DeleteDevice (int deviceId)
        {
            try
            {
                return Ok(await _deviceRepository.DeleteDevice(deviceId));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
