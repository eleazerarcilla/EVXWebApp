using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EvxWebAppCore.Models
{
    public class RouteModel
    {

        public RouteModel(int routeID, int tableLineID, string routeName, int stationCount)
        {
            this.RouteID = routeID;
            this.TableLineID = tableLineID;
            this.RouteName = routeName;
            this.StationCount = stationCount;
        }
        [JsonProperty("ID")]
        public int RouteID { get; set; }
        [JsonProperty("tblLineID")]
        public int TableLineID { get; set; }
        [JsonProperty("routeName")]
        public string RouteName { get; set; }
        [JsonProperty("noOfStations")]
        public int StationCount { get; set; }

    }
}
