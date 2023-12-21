using challenge.domain.layer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace challenge.domain.layer.Models.Response
{
    public class GetUsersResponse
    {
        [JsonPropertyName("@odata.context")]
        public string ODataContext { get; set; }

        [JsonPropertyName("value")]
        public List<User> Value { get; set; }

        public GetUsersResponse()
        {
            ODataContext = string.Empty;
            Value = new List<User>();
        }
    }
}
