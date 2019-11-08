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
    public class DriverRepository: IDriver
    {
        Logger _logger = LogManager.GetLogger("EVX-APIRequestHelper");
        private readonly RequestData _requestData;
        public DriverRepository(IOptions<RequestData> requestData)
        {
            _requestData = requestData.Value;
        }
        public async Task<List<UserDetailModel>> GetDrivers(int AdminID)
        {
            try
            {
                return await Task.FromResult(JsonConvert.DeserializeObject<List<UserDetailModel>>(await new APIRequestHelper().SendRequest(new RequestData
                {
                    APIBaseAddress = _requestData.APIBaseAddress,
                    Method = HttpMethod.Get,
                    FunctionName = "users/driver/get.php",
                    Parameters = $"?adminUserID={AdminID}"
                })));
            }catch(Exception ex)
            {
                _logger.Error(ex);
            }
            return null;
        }
    }
}
