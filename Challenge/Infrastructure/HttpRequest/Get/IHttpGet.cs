using System.Net.Http.Headers;

namespace Challenge.bootstrapper.layer.api.Infrastructure.HttpRequest.Get
{
    public interface IHttpGet<T>
    {
        Task<T> Request(string client, AuthenticationHeaderValue? Auth = null, int? Timeout = null, Dictionary<string, string>? Headers = null);
    }
}
