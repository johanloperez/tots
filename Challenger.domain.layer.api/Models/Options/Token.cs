using System.Text.Json.Serialization;

namespace challenge.domain.layer.Models.Options
{
    public class Token
    {

        [JsonPropertyName("client_id")]
        public string ClientId { get; set; }

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
            //RedirectUri =
            Scope = string.Empty;
            //Code = string.Empty;
        }
    }
}
