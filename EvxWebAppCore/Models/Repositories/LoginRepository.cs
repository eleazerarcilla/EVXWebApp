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
        public async Task<bool> LoginAttempt(Dictionary<string, string> Credentials)
        {
            try
            {
                string username = Credentials.GetValueOrDefault("uname").ToString(), password = Credentials.GetValueOrDefault("pword").ToString();
                using (MD5 md5hash = MD5.Create())
                {
                    UserDetailModel result = JsonConvert.DeserializeObject<UserDetailModel>(await new APIRequestHelper().SendRequest(
                     new RequestData
                     {
                         APIBaseAddress = requestData.APIBaseAddress,
                         ContentType = requestData.ContentType,
                         Method = HttpMethod.Get,
                         FunctionName = "users/getUserDetails.php",
                         Paramters = $"?username={username}&emailAddress={password}"
                     }));
                    return await Task.FromResult(GlobalHelpers.VerifyMd5Hash(md5hash, password, result.password)
                        && result.userType == GlobalEnums.UserTypes.Administrator.ToString());
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
            }
            return false;
        }
    }
}
