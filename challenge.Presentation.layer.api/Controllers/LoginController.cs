using challenge.domain.layer.Models.Options;
using challenge.presentation.layer.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Web;

namespace challenge.presentation.layer.Controllers
{
    public class LoginController
    {
        private readonly GetTokenDelegate _tokenDelegateBody;
        private readonly Urls _urls;

        public LoginController(IOptions<Urls> urls, IOptions<GetTokenDelegate> tokenDelegateBody)
        {
            _tokenDelegateBody = tokenDelegateBody.Value;
            _urls = urls.Value;
        }

        [HttpGet("GetLink")]
        public ActionResult<string> GetLink()
        {
            var uri = $"{_urls.GetCode}{ToQueryString(_tokenDelegateBody)}";
            return uri;
        }

        private static string ToQueryString(object obj)
        {
            var properties = obj.GetType().GetProperties();
            var parameters = properties
                .Select(p =>
                {
                    var attribute = (JsonPropertyNameAttribute)p.GetCustomAttribute(typeof(JsonPropertyNameAttribute));
                    var name = attribute?.Name ?? p.Name;
                    return $"{name}={HttpUtility.UrlEncode(p.GetValue(obj)?.ToString())}";
                });

            return "?" + string.Join("&", parameters);
        }
    }
}
