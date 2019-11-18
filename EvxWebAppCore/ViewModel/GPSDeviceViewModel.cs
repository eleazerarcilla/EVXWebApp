using EvxWebAppCore.Common;
using EvxWebAppCore.Common.Interfaces;
using EvxWebAppCore.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EvxWebAppCore.ViewModel
{
    public class GPSDeviceViewModel
    {
        public DeviceModel Device { get; set; }
        public DeviceModelPHP DevicePHP { get; set; }
        public List<SelectListItem> Drivers { get; set; }
        public List<SelectListItem> Lines { get; set; }
        public GPSDeviceViewModel(DeviceModel device)
        {
            Initialize();
            if (device != null)
            {
                Device = device;
                MapDeviceModelToPHPModel(device);
                Device.Model = string.IsNullOrEmpty(device.Model) ? string.Empty : device.Model;
                Device.networkList = new List<SelectListItem>();
                Device.networkList.Add(new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem("Globe", "Globe",
                    device.Model.Equals("Globe", StringComparison.OrdinalIgnoreCase) ? true : false));

                Device.networkList.Add(new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem("Smart", "Smart",
                    device.Model.Equals("Smart", StringComparison.OrdinalIgnoreCase) ? true : false));
               
            }
        }
        public void MapDeviceModelToPHPModel(DeviceModel device)
        {
            DevicePHP.model = device.Model;
            DevicePHP.name = device.DeviceName;
            DevicePHP.phoneNo = device.Contact;
            DevicePHP.plateNumber = device.Model;
        }
        public void Initialize()
        {
            Device = new DeviceModel();
            DevicePHP = new DeviceModelPHP();
            Lines = new List<SelectListItem>();
            Drivers = new List<SelectListItem>();
        }
    }
}
