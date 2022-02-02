using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApplicationForCash.Models
{
    public class CashRequest
    {
        [Key]
        [JsonProperty(PropertyName = "request_id")]
        public int RequestID { get; set; }

        [JsonProperty(PropertyName = "client_id")]
        public int ClientID { get; set; }

        [JsonProperty(PropertyName = "departemnt_address")]
        public string DepartmentAddress { get; set; }

        [JsonProperty(PropertyName = "amount")]
        public int Amount { get; set; }

        [JsonProperty(PropertyName = "currency")]
        public string Currency { get; set; }

        [JsonProperty(PropertyName = "request_status")]
        public bool RequestStatus { get; set; }

        [JsonProperty(PropertyName = "status_comment")]
        public string StatusComment { get; set; }
    }
}
