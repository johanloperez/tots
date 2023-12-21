using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace challenge.domain.layer.Models.Options
{
    public class TokenDelegate
    {
        [JsonPropertyName("client_id")]
        public string ClientId { get; set; }

        [JsonPropertyName("scope")]
        public string Scope { get; set; }

        [JsonPropertyName("response_type")]
        public string ResponseType { get; set; }

        public TokenDelegate()
        {
            ResponseType =
            ClientId =
            Scope = string.Empty;
        }

    }
}
