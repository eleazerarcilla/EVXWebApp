using EvxWebAppCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EvxWebAppCore.Common.Interfaces
{
    public interface ILogin
    {
        Task<bool> LoginValidation(UserDetailModel user, Dictionary<string, string> Credentials);
        Task<UserDetailModel> GetUserDetails(Dictionary<string, string> Credentials);
    }
}
