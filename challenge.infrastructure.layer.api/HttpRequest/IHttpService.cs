using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace challenge.infrastructure.layer.api.HttpRequest
{
    public interface IHttpService<T>
    {
        Task<T> Post(string client, HttpContent body, AuthenticationHeaderValue? Auth = null, int? Timeout = null, Dictionary<string, string>? Headers = null);
        Task<T> Get(string client, AuthenticationHeaderValue? Auth = null, int? Timeout = null, Dictionary<string, string>? Headers = null);
    }
}
