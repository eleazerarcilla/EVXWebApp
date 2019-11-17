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
    public class DeviceRepository : IDevice
    {
        Logger _logger = LogManager.GetLogger("EVX-APIRequestHelper");
        private readonly RequestData _requestData;
        public DeviceRepository(IOptions<RequestData> requestData)
        {
            _requestData = requestData.Value;
        }
        public async Task<List<DeviceModel>> GetDevices()
        {
            try
            {
                return await Task.FromResult(JsonConvert.DeserializeObject<List<DeviceModel>>(await new APIRequestHelper().SendRequest(new RequestData
                {
                    APIBaseAddress = _requestData.APIBaseAddress,
                    Method = HttpMethod.Get,
                    FunctionName = "/devices/getDevices.php"
                })));
            }catch(Exception ex)
            {
                _logger.Error(ex);
            }
            return null;
        }

        public Task<List<DeviceModel>> UpdateDevice(DeviceModel device)
        {
            throw new NotImplementedException();
        }

        public Task<List<DeviceModel>> DeleteDevice(DeviceModel device)
        {
            throw new NotImplementedException();
        }
    }
}
