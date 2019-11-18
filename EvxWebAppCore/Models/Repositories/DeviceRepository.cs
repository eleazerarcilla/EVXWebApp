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
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
            }
            return null;
        }

        public async Task<CrudApiReturn> AddDevice(DeviceModelPHP device)
        {
            try
            {
                return await Task.FromResult(JsonConvert.DeserializeObject<CrudApiReturn>(await new APIRequestHelper().SendRequest(new RequestData
                {
                    APIBaseAddress = _requestData.APIBaseAddress,
                    Method = HttpMethod.Get,
                    FunctionName = "devices/createDevices.php",
                    Parameters = $"?name={device.name}&uniqueId={device.uniqueId}&model={device.model}&plateNumber={device.plateNumber}&tblRoutesID={device.tblRoutesID}&tblUsersID={device.tblUsersID}&tblLineID={device.tblLineID}"
                })));
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
            }
            return new CrudApiReturn { status = "false" };
        }
        public async Task<CrudApiReturn> UpdateDevice(DeviceModelPHP device)
        {
            try
            {
                return await Task.FromResult(JsonConvert.DeserializeObject<CrudApiReturn>(await new APIRequestHelper().SendRequest(new RequestData
                {
                    APIBaseAddress = _requestData.APIBaseAddress,
                    Method = HttpMethod.Post,
                    ContentType = "application/x-www-form-urlencoded",
                    FunctionName = "devices/updateDevice.php",
                    JSONData = $"deviceID={device.deviceID}&name={device.name}&uniqueId={device.uniqueId}&phoneNo={device.phoneNo}" +
                    $"&model={device.model}&plateNumber={device.plateNumber}&tblRoutesID={device.tblRoutesID}&tblUsersID={device.tblUsersID}&tblLineID={device.tblLineID}"
                })));
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
            }
            return new CrudApiReturn { status = "false" };
        }

        public async Task<CrudApiReturn> DeleteDevice(int deviceID)
        {
            try
            {
                return await Task.FromResult(JsonConvert.DeserializeObject<CrudApiReturn>(await new APIRequestHelper().SendRequest(new RequestData
                {
                    APIBaseAddress = _requestData.APIBaseAddress,
                    Method = HttpMethod.Get,
                    FunctionName = "devices/deleteDevice.php",
                    Parameters = $"?id={deviceID}"
                })));
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
            }
            return new CrudApiReturn { status = "false" };
        }
    }
}
