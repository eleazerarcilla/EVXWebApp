﻿using EvxWebAppCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EvxWebAppCore.Common.Interfaces
{
    public interface IDevice
    {
        Task<List<DeviceModel>> GetDevices();
    }
}
