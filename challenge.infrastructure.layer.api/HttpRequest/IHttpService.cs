using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace challenge.infrastructure.layer.HttpRequest
{
    public interface IHttpService<T>
    {
        Task<T> Post(string client, HttpContent body, AuthenticationHeaderValue ? Auth = null, string? uri = null, int? Timeout = null, Dictionary<string, string>? Headers = null);
        Task<T> Get(string client, AuthenticationHeaderValue? Auth = null, string? uri = null, int? Timeout = null, Dictionary<string, string>? Headers = null);
        Task<bool> Delete(string client, AuthenticationHeaderValue? Auth = null, string? uri = null, int? Timeout = null, Dictionary<string, string>? Headers = null);
        Task<T> Put(string client, AuthenticationHeaderValue? Auth = null, string? uri = null, int? Timeout = null, Dictionary<string, string>? Headers = null);
    }
}
