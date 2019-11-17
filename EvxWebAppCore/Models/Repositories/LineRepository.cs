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
    public class LineRepository : ILine
    {
        Logger _logger = LogManager.GetLogger("EVX-APIRequestHelper");
        private readonly RequestData _requestData;
        public LineRepository(IOptions<RequestData> requestData)
        {
            _requestData = requestData.Value;
        }
        public async Task<List<LineModel>> GetLines(int adminID)
        {
            try
            {
                return await Task.FromResult(JsonConvert.DeserializeObject<List<LineModel>>(await new APIRequestHelper().SendRequest(
                    new RequestData
                    {
                        APIBaseAddress = _requestData.APIBaseAddress,
                        Method = HttpMethod.Get,
                        FunctionName = "lines/getLines.php",
                        Parameters = adminID == 0 ? null : $"?adminUserID={adminID}"
                    })));
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
            }
            return null;
        }
        public async Task<CrudApiReturn> AddLine(string newLineName, int newAdminUserID)
        {
            try
            {
                var crudApiReturn = await Task.FromResult(JsonConvert.DeserializeObject<CrudApiReturn>(await new APIRequestHelper().SendRequest(
                    new RequestData
                    {
                        APIBaseAddress = _requestData.APIBaseAddress,
                        Method = HttpMethod.Post,
                        FunctionName = "lines/addLine.php",
                        ContentType = "application/x-www-form-urlencoded",
                        JSONData = $"lineName={newLineName}&adminUserID={newAdminUserID}"
                    })));
                return crudApiReturn;
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
            }
            return null;
        }
        public async Task<CrudApiReturn> UpdateLine(int lineID, string newLineName, int newAdminUserID)
        {
            try
            {
                var crudApiReturn = await Task.FromResult(JsonConvert.DeserializeObject<CrudApiReturn>(await new APIRequestHelper().SendRequest(
                    new RequestData
                    {
                        APIBaseAddress = _requestData.APIBaseAddress,
                        Method = HttpMethod.Post,
                        FunctionName = "lines/updateLine.php",
                        ContentType= "application/x-www-form-urlencoded",
                        JSONData = $"lineID={lineID}&newLineName={newLineName}&newAdminUserID={newAdminUserID}"
                    })));
                return crudApiReturn;
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
            }
            return null;
        }

        public async Task<CrudApiReturn> DeleteLine(int lineID)
        {
            try
            {
                var crudApiReturn = await Task.FromResult(JsonConvert.DeserializeObject<CrudApiReturn>(await new APIRequestHelper().SendRequest(
                    new RequestData
                    {
                        APIBaseAddress = _requestData.APIBaseAddress,
                        Method = HttpMethod.Get,
                        FunctionName = "lines/deleteLine.php",
                        Parameters = $"?lineID={lineID}"
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
