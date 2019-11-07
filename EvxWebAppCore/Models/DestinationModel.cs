using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static EvxWebAppCore.Common.GlobalEnums;

namespace EvxWebAppCore.Models
{
    public class DestinationModel
    {
        [JsonProperty("ID")]
        public int DestinationID { get; set; }
        [JsonProperty("tblRouteID")]
        public int TableRouteID { get; set; }
        [JsonProperty("Value")]
        public string Value { get; set; }
        [JsonProperty("Description")]
        public string Description { get; set; }
        [JsonProperty("OrderOfArrival")]
        public int OrderOfArrival { get; set; }
        [JsonProperty("Direction")]
        public string Direction { get; set; }
        [JsonProperty("Lat")]
        public double Latitude { get; set; }
        [JsonProperty("Lng")]
        public double Longitude { get; set; }
        [JsonProperty("distanceFromPreviousStation")]
        public double DistanceFromPreviousStation { get; set; }
        [JsonProperty("isMainTerminal")]
        public int IsMainTerminal { get; set; }
        [JsonProperty("IsActive")]
        public int IsActive { get; set; }
        [JsonProperty("routeName")]
        public string RouteName { get; set; }
        [JsonProperty("LineName")]
        public string LineName { get; set; }
        [JsonProperty("LineID")]
        public int LineID { get; set; }
    }
}
