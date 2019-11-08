using EvxWebAppCore.Common;
using EvxWebAppCore.Common.Interfaces;
using EvxWebAppCore.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using Microsoft.Extensions.Options;
using System.Security.Cryptography;
using NLog;
using Microsoft.AspNetCore.Http;

namespace EvxWebAppCore.Models.Repositories
{
    public class LoginRepository : ILogin
    {
        Logger _logger = LogManager.GetLogger("EVX-APIRequestHelper");
        private readonly RequestData requestData;

        public LoginRepository(IOptions<RequestData> _requestData)
        {
            requestData = _requestData.Value;
        }
        public async Task<bool> LoginValidation(UserDetailModel user, Dictionary<string, string> Credentials)
        {
            try
            {
                string username = Credentials.GetValueOrDefault("uname").ToString(), password = Credentials.GetValueOrDefault("pword").ToString();
                using (MD5 md5hash = MD5.Create())
                {
                    return await Task.FromResult(GlobalHelpers.VerifyMd5Hash(md5hash, password, user.password)
                        && user.userType == GlobalEnums.UserTypes.Administrator.ToString());
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
            }
            return false;
        }
        public async Task<UserDetailModel> GetUserDetails(Dictionary<string, string> Credentials)
        {
            try
            {
                string username = Credentials.GetValueOrDefault("uname").ToString(), password = Credentials.GetValueOrDefault("pword").ToString();
                return await Task.FromResult(JsonConvert.DeserializeObject<UserDetailModel>(await new APIRequestHelper().SendRequest(
                     new RequestData
                     {
                         APIBaseAddress = requestData.APIBaseAddress,
                         ContentType = requestData.ContentType,
                         Method = HttpMethod.Get,
                         FunctionName = "users/getUserDetails.php",
                         Parameters = $"?username={username}&emailAddress={password}"
                     })));
            }
            catch(Exception ex)
            {
                _logger.Error(ex);
            }
            return null;
        }
    }
}
