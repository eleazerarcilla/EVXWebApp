using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EvxWebAppCore.Models
{
    public class UserDetailModel
    {
        public string username { get; set; }
        public string emailAddress { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string UserID { get; set; }
        public string deviceId { get; set; }
        public string userType { get; set; }
        public string authType { get; set; }
        public string password { get; set; }
        public string IsActive { get; set; }

    }
}
