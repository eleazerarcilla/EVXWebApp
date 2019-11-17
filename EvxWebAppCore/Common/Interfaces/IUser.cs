using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EvxWebAppCore.Models;

namespace EvxWebAppCore.Common.Interfaces
{
    public interface IUser
    {
        Task<List<UserDetailModel>> GetUsers();
        Task<List<UserDetailModel>> GetUsers(string userType);
    }
}
