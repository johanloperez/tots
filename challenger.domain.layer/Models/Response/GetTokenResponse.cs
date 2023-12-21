using System.Text.Json.Serialization;

namespace challenge.domain.layer.Models.Response
{
    public class GetTokenResponse
    {
        [JsonPropertyName("token_type")]
        public string TokenType { get; set; }

        [JsonPropertyName("expires_in")]
        public long ExpiresIn { get; set; }

        [JsonPropertyName("ext_expires_in")]
        public long ExtExpiresIn { get; set; }

        [JsonPropertyName("access_token")]
        public string AccessToken { get; set; }

        public GetTokenResponse()
        {
            TokenType =
            AccessToken = string.Empty;
        }

    }
}
