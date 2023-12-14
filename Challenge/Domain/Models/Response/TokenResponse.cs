namespace Challenge.bootstrapper.layer.api.Models.Response
{
    public class TokenResponse
    {
        public string token_type { get; set; }
        public long expires_in { get; set; }
        public long ext_expires_in { get; set; }
        public string access_token { get; set; }

        public TokenResponse()
        {
            token_type =
            access_token = string.Empty;
        }

    }
}
