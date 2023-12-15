using challenge.domain.layer.api.Models.Options;
using challenge.domain.layer.Models.Options;
using challenge.presentation.layer.api.Controllers;
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
    public class TestController : BaseController
    {
        private readonly GetTokenDelegate _tokenDelegateBody;
        private readonly Urls _urls;

        public TestController(IOptions<Urls> urls, IOptions<GetTokenDelegate> tokenDelegateBody)
        {
            _tokenDelegateBody = tokenDelegateBody.Value;
            _urls = urls.Value;
        }

        [HttpGet("GetLink")]
        public IActionResult GetLink()
        {
            var uri = $"{_urls.GetCode}{ToQueryString(_tokenDelegateBody)}";

            return Ok(uri);
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
