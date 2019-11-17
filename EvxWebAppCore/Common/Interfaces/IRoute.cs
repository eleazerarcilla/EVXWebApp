using EvxWebAppCore.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EvxWebAppCore.Common.Interfaces
{
    public interface IRoute
    {
        Task<List<RouteModel>> GetRoute(int lineID);

        
        Task<CrudApiReturn> AddRoute(int lineID, string routeName);

        Task<CrudApiReturn> UpdateRoute(int routeID, string newRouteName);

        Task<CrudApiReturn> DeleteRoute(int routeID);
    }
}
