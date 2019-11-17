using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EvxWebAppCore.Models
{
    public class LineModel
    {
        public LineModel(int lineID, string lineName, int adminUserID, string adminUserName)
        {
            this.LineID = lineID;
            this.LineName = lineName;
            this.AdminUserID = adminUserID;
            this.AdminUserName = adminUserName;
        }

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
