using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApplicationForCash.Models.RequestModels
{
    public class JsonSaveRequest
    {
        [JsonProperty("client_id")]
        public int ClientID { get; set; }

        [JsonProperty("departemnt_address")]
        public string DepartmentAddress { get; set; }

        [JsonProperty("amount")]
        public int Amount { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }
    }
}
