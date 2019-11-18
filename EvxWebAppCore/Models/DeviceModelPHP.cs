using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EvxWebAppCore.Models
{
    public class DeviceModelPHP
    {
        [JsonProperty("deviceID")]
        public int deviceID { get; set; }
        [JsonProperty("name")]
        public string name { get; set; }
        [JsonProperty("uniqueId")]
        public string uniqueId  { get; set; }
        [JsonProperty("phoneNo")]
        public string phoneNo { get; set; }
        [JsonProperty("model")]
        public string model { get; set; }
        [JsonProperty("plateNumber")]
        public string plateNumber { get; set; }
        [JsonProperty("tblRoutesID")]
        public int tblRoutesID { get; set; } = 0;
        [JsonProperty("tblUsersID")]
        public int tblUsersID { get; set; } = 0;
        [JsonProperty("tblLineID")]
        public int tblLineID { get; set; } = 0;
    }
}
