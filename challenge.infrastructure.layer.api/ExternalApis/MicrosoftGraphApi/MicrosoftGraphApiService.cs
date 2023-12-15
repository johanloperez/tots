using challenge.infrastructure.layer.api.HttpRequest;
using challenge.domain.layer.api.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using challenge.domain.layer.api.Models.Options;
using Microsoft.Extensions.Options;
using System.Text.Json;
using Challenge.infrastructure.layer.api.Helpers;

namespace challenge.infrastructure.layer.api.ExternalApis.MicrosoftGraphApi
{
    public class MicrosoftGraphApiService
    {
        private readonly IHttpService<TokenResponse> _httpService;
        private readonly Token _tokenBody;

        public MicrosoftGraphApiService(IHttpService<TokenResponse> httpService, IOptions<Token> tokenBody)
        {
            _httpService = httpService;
            _tokenBody = tokenBody.Value;
        }

        public async Task<string> RequestAccessToken()
        {
            if (CustomValidations.AnyPropertyNullOrEmpty(_tokenBody))
                throw new Exception("Faltan parametros necesarios para solicitar el token.");

            var json = JsonSerializer.Serialize(_tokenBody);
            var dictionary = JsonSerializer.Deserialize<Dictionary<string, string>>(json);

            if (dictionary is null)
                throw new Exception("Error a deserializar el json del objecto de los parametros para solicitar el token.");

            var body = new FormUrlEncodedContent(dictionary);

            var JsonContent = await _httpService.Post("token", body);

            if (JsonContent.access_token is null)
                throw new Exception("código inválido");

            return JsonContent.access_token;
        }
    }
}
