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

        public async Task<CrudApiReturn> AddDriver(string username, string firstname, string lastname, string password, int tblLineID)
        {
            try
            {
                return await Task.FromResult(JsonConvert.DeserializeObject<CrudApiReturn>(await new APIRequestHelper().SendRequest(new RequestData
                {
                    APIBaseAddress = _requestData.APIBaseAddress,
                    Method = HttpMethod.Post,
                    ContentType = "application/x-www-form-urlencoded",
                    FunctionName = "users/driver/add.php",
                    JSONData = $"username={username}&firstname={firstname}&lastname={lastname}&password={password}&tblLineID={tblLineID}"
                }))); ;
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
            }
            return new CrudApiReturn { status = "false" };
        }

        public async Task<CrudApiReturn> UpdateDriver(int userID, string newusername, string newfirstname, string newlastname, int newLineID)
        {
            try
            {
                return await Task.FromResult(JsonConvert.DeserializeObject<CrudApiReturn>(await new APIRequestHelper().SendRequest(new RequestData
                {
                    APIBaseAddress = _requestData.APIBaseAddress,
                    Method = HttpMethod.Post,
                    ContentType = "application/x-www-form-urlencoded",
                    FunctionName = "driver/edit.php",
                    JSONData = $"userID={userID}&newusername={newusername}&newfirstname={newfirstname}&newlastname={newlastname}&newlineid={newLineID}"
                }))); ;
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
            }
            return new CrudApiReturn { status = "false" };
        }

        public async Task<CrudApiReturn> DeleteDriver(int userID)
        {
            try
            {
                return await Task.FromResult(JsonConvert.DeserializeObject<CrudApiReturn>(await new APIRequestHelper().SendRequest(new RequestData
                {
                    APIBaseAddress = _requestData.APIBaseAddress,
                    Method = HttpMethod.Post,
                    ContentType = "application/x-www-form-urlencoded",
                    FunctionName = "driver/delete.php",
                    JSONData = $"userID={userID}"
                }))); ;
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
            }
            return new CrudApiReturn { status = "false" };
        }
    }
}
