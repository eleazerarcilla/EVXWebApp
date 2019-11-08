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

    }
}
