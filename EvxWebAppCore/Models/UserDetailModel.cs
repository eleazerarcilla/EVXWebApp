using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EvxWebAppCore.Models
{
    public class UserDetailModel
    {

        
        [JsonProperty("username")]
        public string username { get; set; }
        
        [JsonProperty("emailAddress")]
        public string emailAddress { get; set; }

        [JsonProperty("firstName")]
        public string firstName { get; set; }

        [JsonProperty("lastName")]
        public string lastName { get; set; }

        /*Because API is sometimes returning UserID or ID...
         Need to refactor API but mobile app will be affected so this is the workaround
         Creeate 2 objects UserID and ID*/
        [JsonProperty("UserID")]
        public int UserID { get; set; }

        [JsonProperty("ID")]
        public int ID { get; set; }

        [JsonProperty("deviceId")]
        public string deviceId { get; set; }

        [JsonProperty("userType")]
        public string userType { get; set; }

        [JsonProperty("authType")]
        public string authType { get; set; }

        [JsonProperty("password")]
        public string password { get; set; }

        [JsonProperty("IsActive")]
        public string IsActive { get; set; }

    }
}

