using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EvxWebAppCore.Models
{
    public class DeviceModel
    {
        [JsonProperty("id")]
        public int DeviceID { get; set; }
        [JsonProperty("attributes")]
        public object Attributes { get; set; }
        
        [JsonProperty("name")]
        public string DeviceName { get; set; }
        [JsonProperty("uniqueId")]
        public string UniqueID { get; set; }
        [JsonProperty("status")]
        public string DeviceStatus { get; set; }
        [JsonProperty("lastUpdate")]
        public string LastUpdate { get; set; }
        [JsonProperty("positionId")]
        public int PositionID { get; set; }
        [JsonProperty("geofenceIds")]
        public int[] GeofenceIds { get; set; }
        [JsonProperty("phone")]
        public string Phone { get; set; }
        [JsonProperty("model")]
        public string Model { get; set; }
        [JsonProperty("contact")]
        public string Contact { get; set; }
        [JsonProperty("category")]
        public string Category { get; set; }
        [JsonProperty("disabled")]
        public string Disabled { get; set; }

        [JsonProperty("networkList")]
        public List<SelectListItem> networkList { get; set; }
    }
}
