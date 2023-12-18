using challenge.domain.layer.Entities;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace challenge.domain.layer.Models.Response
{
    public class GetEventResponse
    {
        [JsonPropertyName("@odata.context")]
        public string ODataContext { get; set; }

        [JsonPropertyName("value")]
        public List<Event> Value { get; set; }


        public GetEventResponse()
        {
            ODataContext = string.Empty;
            Value = new List<Event>();
        }
    }
}
