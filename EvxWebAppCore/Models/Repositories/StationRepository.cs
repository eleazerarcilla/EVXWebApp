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
    public class StationRepository: IStation
    {
        Logger _logger = LogManager.GetLogger("EVX-APIRequestHelper");
        private readonly RequestData _requestData;
        public StationRepository(IOptions<RequestData> requestData)
        {
            _requestData = requestData.Value;
        }
        public async Task<List<StationModel>> GetStations(int RouteID)
        {
            try
            {
                return await Task.FromResult(JsonConvert.DeserializeObject<List<StationModel>>(await new APIRequestHelper().SendRequest(new RequestData
                {
                    APIBaseAddress = _requestData.APIBaseAddress,
                    Method = HttpMethod.Get,
                    FunctionName = "destinations/",
                    Parameters = RouteID == 0 ? "getDestinations.php" : $"getDestinationsByRouteID.php?routeID={RouteID}"
                })));
            }catch(Exception ex)
            {
                _logger.Error(ex);
            }
            return null;
        }
    }
}
