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


        Task<CrudApiReturn> AddStation(string value, double lat, double lng, int tblRouteID, string direction, int isMainterminal);
        Task<CrudApiReturn> UpdateStation(int id, string name, double lat, double lng, int tblRouteID, string direction, int isMainterminal);
        Task<CrudApiReturn> DeleteStation(int destinationid);

    }
}
