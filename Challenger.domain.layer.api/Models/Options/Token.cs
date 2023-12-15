using System.Text.Json.Serialization;

namespace challenge.domain.layer.api.Models.Options
{
    public class Token
    {
        [JsonPropertyName("redirect_uri")]
        public string RedirectUri { get; set; }

        [JsonPropertyName("client_id")]
        public string ClientId { get; set; }

        [JsonPropertyName("code")]
        public string Code { get; set; }

        [JsonPropertyName("client_secret")]
        public string ClientSecret { get; set; }

        [JsonPropertyName("grant_type")]
        public string GrantType { get; set; }
        
        [JsonPropertyName("scope")]
        public string Scope { get; set; }

        public Token()
        {
            GrantType =
            ClientId =
            ClientSecret =
            RedirectUri =
            Scope =
            Code = string.Empty;
        }
    }
}
