using EvxWebAppCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EvxWebAppCore.Common.Interfaces
{
    public interface IStation
    {
        Task<List<StationModel>> GetStations(int RouteID);
    }
}
