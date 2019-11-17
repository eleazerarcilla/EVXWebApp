using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EvxWebAppCore.Common.Interfaces;
using EvxWebAppCore.Common;
using Microsoft.Extensions.Options;
using NLog;
using System.Net.Http;
using Newtonsoft.Json;

namespace EvxWebAppCore.Models.Repositories 
{ 
    public class UserRepository : IUser
    {
        Logger _logger = LogManager.GetLogger("EVX-APIRequestHelper");
        private readonly RequestData _requestData;
        public UserRepository(IOptions<RequestData> requestData)
        {
            _requestData = requestData.Value;
        }
        public Task<List<UserDetailModel>> GetUsers()
        {
            throw new NotImplementedException();
        }

        public async Task<List<UserDetailModel>> GetUsers(string userType)
        {
            try
            {
                return await Task.FromResult(JsonConvert.DeserializeObject<List<UserDetailModel>>(await new APIRequestHelper().SendRequest(
                    new RequestData
                    {
                        APIBaseAddress = _requestData.APIBaseAddress,
                        Method = HttpMethod.Get,
                        FunctionName = "users/getUsersByType.php",
                        Parameters = $"?usertype={userType}"
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
