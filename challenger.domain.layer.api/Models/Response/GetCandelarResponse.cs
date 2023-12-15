using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace challenge.domain.layer.Models.Response
{
    public class GetCalendarResponse
    {
        [JsonPropertyName("@odata.context")]
        public string ODataContext { get; set; }

        [JsonPropertyName("@odata.id")]
        public string ODataId { get; set; }

        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("color")]
        public string Color { get; set; }

        [JsonPropertyName("isDefaultCalendar")]
        public bool IsDefaultCalendar { get; set; }

        [JsonPropertyName("changeKey")]
        public string ChangeKey { get; set; }

        [JsonPropertyName("canShare")]
        public bool CanShare { get; set; }

        [JsonPropertyName("canViewPrivateItems")]
        public bool CanViewPrivateItems { get; set; }

        [JsonPropertyName("hexColor")]
        public string HexColor { get; set; }

        [JsonPropertyName("canEdit")]
        public bool CanEdit { get; set; }

        [JsonPropertyName("allowedOnlineMeetingProviders")]
        public List<string> AllowedOnlineMeetingProviders { get; set; }

        [JsonPropertyName("defaultOnlineMeetingProvider")]
        public string DefaultOnlineMeetingProvider { get; set; }

        [JsonPropertyName("isTallyingResponses")]
        public bool IsTallyingResponses { get; set; }

        [JsonPropertyName("isRemovable")]
        public bool IsRemovable { get; set; }

        [JsonPropertyName("owner")]
        public Owner Owner { get; set; }

        public GetCalendarResponse()
        {
            ODataContext =
            ODataId =
            Id =
            Name =
            Color =
            ChangeKey =
            HexColor =
            DefaultOnlineMeetingProvider = string.Empty;
            AllowedOnlineMeetingProviders = new List<string>();
            Owner = new Owner();
        }
    }

    public class Owner
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("address")]
        public string Address { get; set; }

        public Owner()
        {
            Name =
            Address = string.Empty;
        }
    }
}
