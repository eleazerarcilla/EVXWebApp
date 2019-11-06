using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EvxWebAppCore.Models
{
    public class RouteModel
    {
        [JsonProperty("ID")]
        public int RouteID { get; set; }
        [JsonProperty("tblLineID")]
        public string TableLineID { get; set; }
        [JsonProperty("routeName")]
        public string RouteName { get; set; }
        [JsonProperty("noOfStations")]
        public int StationCount { get; set; }

    }
}
