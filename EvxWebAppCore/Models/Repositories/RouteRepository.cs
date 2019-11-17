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
        private readonly RequestData _requestData;
        public RouteRepository(IOptions<RequestData> requestData)
        {
            _requestData = requestData.Value;
        }
        public async Task<List<RouteModel>> GetRoute(int LineID)
        {
            try
            {
                if (LineID == 0)
                    return JsonConvert.DeserializeObject<List<RouteModel>>(await new APIRequestHelper().SendRequest(
                        new RequestData
                        {
                            APIBaseAddress = _requestData.APIBaseAddress,
                            Method = HttpMethod.Get,
                            FunctionName = "routes/getRoutes.php"
                        }));
                return JsonConvert.DeserializeObject<List<RouteModel>>(await new APIRequestHelper().SendRequest(
                        new RequestData
                        {
                            APIBaseAddress = _requestData.APIBaseAddress,
                            Method = HttpMethod.Get,
                            FunctionName = "routes/getRoutes.php"
                        })).Where(x => x.TableLineID == LineID).Select(x => x).ToList();
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
            }
            return new List<RouteModel>();
        }

        public async Task<CrudApiReturn> AddRoute(int lineID, string routeName)
        {
            try
            {
                var crudApiReturn = await Task.FromResult(JsonConvert.DeserializeObject<CrudApiReturn>(await new APIRequestHelper().SendRequest(
                    new RequestData
                    {
                        APIBaseAddress = _requestData.APIBaseAddress,
                        Method = HttpMethod.Post,
                        FunctionName = "routes/addRoute.php",
                        ContentType = "application/x-www-form-urlencoded",
                        JSONData = $"lineID={lineID}&routeName={routeName}"
                    })));
                return crudApiReturn;
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
            }
            return null;
        }
        public async Task<CrudApiReturn> UpdateRoute(int routeID, string newRouteName)
        {
            try
            {
                var crudApiReturn = await Task.FromResult(JsonConvert.DeserializeObject<CrudApiReturn>(await new APIRequestHelper().SendRequest(
                    new RequestData
                    {
                        APIBaseAddress = _requestData.APIBaseAddress,
                        Method = HttpMethod.Post,
                        FunctionName = "routes/updateRoute.php",
                        ContentType = "application/x-www-form-urlencoded",
                        JSONData = $"routeID={routeID}&newRouteName={newRouteName}"
                    })));
                return crudApiReturn;
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
            }
            return null;
        }

        public async Task<CrudApiReturn> DeleteRoute(int routeID)
        {
            try
            {
                var crudApiReturn = await Task.FromResult(JsonConvert.DeserializeObject<CrudApiReturn>(await new APIRequestHelper().SendRequest(
                    new RequestData
                    {
                        APIBaseAddress = _requestData.APIBaseAddress,
                        Method = HttpMethod.Get,
                        FunctionName = "routes/deleteRoute.php",
                        Parameters = $"?routeID={routeID}"
                    })));

                return crudApiReturn;
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
            }
            return null;
        }

    }
}
