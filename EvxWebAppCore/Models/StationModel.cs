using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static EvxWebAppCore.Common.GlobalEnums;

namespace EvxWebAppCore.Models
{
    public class StationModel
    {
        public StationModel(int destinationID, int tableRouteID, string value, string description, int orderOfArrival, string direction,
            double latitude, double longitude, double distanceFromPreviousStation, int isMainTerminal, int isActive, string routeName,
            string lineName, int lineID)
        {
            this.DestinationID = destinationID;
            this.TableRouteID = tableRouteID;
            this.Value = value;
            this.Description = description;
            this.OrderOfArrival = orderOfArrival;
            this.Direction = direction;
            this.Latitude = latitude;
            this.Longitude = longitude;
            this.DistanceFromPreviousStation = distanceFromPreviousStation;
            this.IsMainTerminal = isMainTerminal;
            this.IsActive = IsActive;
            this.RouteName = routeName;
            this.LineName = lineName;
            this.LineID = lineID;
        }
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
