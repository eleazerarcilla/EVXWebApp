using EvxWebAppCore.Common;
using EvxWebAppCore.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EvxWebAppCore.Models.Repositories
{
    public class LoginRepository : ILogin
    {
        public async Task<bool> LoginAttempt(RequestData data, Dictionary<string, string> Credentials)
        {
            bool result = false;
            //insert logic here
            return await Task.FromResult(result);
        }
    }
}
