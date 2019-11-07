using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EvxWebAppCore.Models
{
    public class LineModel
    {
        [JsonProperty("ID")]
        public int LineID { get; set; }
        [JsonProperty("Name")]
        public string LineName { get; set; }
        [JsonProperty("Admin_User_ID")]
        public int AdminUserID { get; set; }
        [JsonProperty("AdminUserName")]
        public string AdminUserName { get; set; }
    }
}
