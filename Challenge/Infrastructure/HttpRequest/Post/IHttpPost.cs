using System.Net.Http.Headers;

namespace Challenge.bootstrapper.layer.api.Infrastructure.HttpRequest.Post
{
    public interface IHttpPost<T>
    {
        Task<T> Request(string client, HttpContent body, AuthenticationHeaderValue? Auth = null, int? Timeout = null, Dictionary<string, string>? Headers = null);
    }
}
