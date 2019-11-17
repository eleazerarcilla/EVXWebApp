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

        public async Task<CrudApiReturn> AddStation(string value, double lat, double lng, int tblRouteID, string direction, int isMainterminal)
        {
            try
            {
                var crudApiReturn = await Task.FromResult(JsonConvert.DeserializeObject<CrudApiReturn>(await new APIRequestHelper().SendRequest(
                    new RequestData
                    {
                        APIBaseAddress = _requestData.APIBaseAddress,
                        Method = HttpMethod.Get,
                        FunctionName = "destinations/addDestination.php?",
                        Parameters = $"value={value}&lat={lat}&lng={lng}&tblRouteID={tblRouteID}&direction={direction}&isMainTerminal={isMainterminal}"
                    })));
                return crudApiReturn;
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
            }
            return null;
        }

        public async Task<CrudApiReturn> UpdateStation(int id, string name, double lat, double lng, int tblRouteID, string direction, int isMainterminal)
        {
            try
            {
                var crudApiReturn = await Task.FromResult(JsonConvert.DeserializeObject<CrudApiReturn>(await new APIRequestHelper().SendRequest(
                    new RequestData
                    {
                        APIBaseAddress = _requestData.APIBaseAddress,
                        Method = HttpMethod.Get,
                        FunctionName = "destinations/updateDestination.php?",
                        Parameters = $"id={id}&name={name}&lat={lat}&lng={lng}&tblRouteID={tblRouteID}&direction={direction}&isMainTerminal={isMainterminal }"
                    })));
                return crudApiReturn;
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
            }
            return null;
        }

        public async Task<CrudApiReturn> DeleteStation(int destinationid)
        {
            try
            {
                var crudApiReturn = await Task.FromResult(JsonConvert.DeserializeObject<CrudApiReturn>(await new APIRequestHelper().SendRequest(
                    new RequestData
                    {
                        APIBaseAddress = _requestData.APIBaseAddress,
                        Method = HttpMethod.Get,
                        FunctionName = "destinations/deleteDestination.php",
                        Parameters = $"?destinationid={destinationid}"
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
