using EvxWebAppCore.Common;
using EvxWebAppCore.Common.Interfaces;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace EvxWebAppCore.Models.Repositories
{
    public class RouteRepository : IRoute
    {
        Logger _logger = LogManager.GetLogger("EVX-APIRequestHelper");
        private readonly RequestData requestData;
        public RouteRepository(IOptions<RequestData> _requestData)
        {
            requestData = _requestData.Value;
        }
        public async Task<List<RouteModel>> GetRoute()
        {
            try
            {
                return JsonConvert.DeserializeObject<List<RouteModel>>(await new APIRequestHelper().SendRequest(
                    new RequestData{
                        APIBaseAddress = requestData.APIBaseAddress,
                        Method = HttpMethod.Get,
                        FunctionName = "routes/getRoutes.php"
                    }));
            }catch(Exception ex)
            {
                _logger.Error(ex);
            }
            return new List<RouteModel>();
        }
    }
}
