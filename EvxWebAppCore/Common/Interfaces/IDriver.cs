using EvxWebAppCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EvxWebAppCore.Common.Interfaces
{
    public interface IDriver
    {
        Task<List<UserDetailModel>> GetDrivers(int AdminID);
        Task<CrudApiReturn> AddDriver(string username, string firstname, string lastname, string password, int tblLineID);
    

        Task<CrudApiReturn> UpdateDriver(int userID, string newusername, string newfirstname, string newlastname, int newLineID);

        Task<CrudApiReturn> DeleteDriver(int userID);
    }
}
