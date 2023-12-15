using System.Text.Json.Serialization;

namespace challenge.domain.layer.api.Models.Response
{
    public class TokenResponse
    {
        [JsonPropertyName("token_type")]
        public string TokenType { get; set; }

        [JsonPropertyName("expires_in")]
        public long ExpiresIn { get; set; }

        [JsonPropertyName("ext_expires_in")]
        public long ExtExpiresIn { get; set; }

        [JsonPropertyName("access_token")]
        public string AccessToken { get; set; }

        public TokenResponse()
        {
            TokenType =
            AccessToken = string.Empty;
        }

    }
}
