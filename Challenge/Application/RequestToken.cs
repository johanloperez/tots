using Challenge.bootstrapper.layer.api.Helpers;
using Challenge.bootstrapper.layer.api.Infrastructure.HttpRequest.Get;
using Challenge.bootstrapper.layer.api.Infrastructure.HttpRequest.Post;
using Challenge.bootstrapper.layer.api.Models.Options;
using Challenge.bootstrapper.layer.api.Models.Response;
using Microsoft.Extensions.Options;
using System.Reflection;
using System.Text;
using System.Text.Json;

namespace Challenge.bootstrapper.layer.api.Application
{
    public class RequestToken : IRequestToken
    {
        private readonly IHttpPost<TokenResponse> _post;
        private readonly IHttpGet<dynamic> _get;
        private readonly Token _tokenBody;

        public RequestToken(IHttpPost<TokenResponse> post, IHttpGet<dynamic> get, IOptions<Token> tokenBody)
        {
            _post = post;
            _get = get;
            _tokenBody = tokenBody.Value;
        }

        public async Task<string> Get()
        {
            if (CustomValidations.AnyPropertyNullOrEmpty(_tokenBody))
                throw new Exception("Faltan parametros necesarios para solicitar el token.");

            var json = JsonSerializer.Serialize(_tokenBody);
            var dictionary = JsonSerializer.Deserialize<Dictionary<string, string>>(json);

            if (dictionary is null)
                throw new Exception("Error a deserializar el json del objecto de los parametros para solicitar el token.");

            var body = new FormUrlEncodedContent(dictionary);

            var JsonContent = await _post.Request("token", body);

            if (JsonContent.access_token is null)
                throw new Exception("código inválido");

            return JsonContent.access_token;

        }

        private static Dictionary<string, string?> ConvertToDictionary(object obj)
        {
            if (obj is null)
                throw new ArgumentNullException(nameof(obj));

            var properties = obj.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public);

            var result = properties.ToDictionary(prop => prop.Name, prop => prop.GetValue(obj)?.ToString());

            return result;
        }
    }
}
