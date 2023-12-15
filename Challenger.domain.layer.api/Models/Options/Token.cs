using System.Text.Json.Serialization;

namespace challenge.domain.layer.api.Models.Options
{
    public class Token
    {
        [JsonPropertyName("tenant")]
        public string Tenant { get; set; }

        [JsonPropertyName("client_id")]
        public string ClientId { get; set; }

        [JsonPropertyName("scope")]
        public string Scope { get; set; }

        [JsonPropertyName("client_secret")]
        public string ClientSecret { get; set; }

        [JsonPropertyName("grant_type")]
        public string GrantType { get; set; }

        public Token()
        {
            GrantType =
            ClientId =
            ClientSecret =
            Tenant =
            Scope = string.Empty;
        }
    }
}
