using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace challenge.domain.layer.Models.Options
{
    public class GetTokenDelegate
    {
        [JsonPropertyName("client_id")]
        public string ClientId { get; set; }

        [JsonPropertyName("scope")]
        public string Scope { get; set; }

        [JsonPropertyName("response_type")]
        public string ResponseType { get; set; }

        public GetTokenDelegate()
        {
            ResponseType =
            ClientId =
            Scope = string.Empty;
        }

    }
}
