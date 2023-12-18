using System.Text.Json.Serialization;

namespace challenge.domain.layer.Dtos
{
    public class EventDto
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("organizer")]
        public OrganizerDto Organizer { get; set; }

        [JsonPropertyName("body")]
        public BodyDto Body { get; set; }

        [JsonPropertyName("start")]
        public MeetingDateTimeDto Start { get; set; }

        [JsonPropertyName("end")]
        public MeetingDateTimeDto End { get; set; }

        [JsonPropertyName("responseStatus")]
        public ResponseStatusDto ResponseStatus { get; set; }

        public EventDto()
        {
            Id = string.Empty;
        }
    }

    public class ResponseStatusDto
    {
        [JsonPropertyName("response")]
        public string Response { get; set; }

        [JsonPropertyName("time")]
        public DateTime Time { get; set; }

        public ResponseStatusDto()
        {
            Response = string.Empty;
            Time = DateTime.MinValue;
        }
    }

    public class BodyDto
    {
        [JsonPropertyName("contentType")]
        public string ContentType { get; set; }

        [JsonPropertyName("content")]
        public string Content { get; set; }

        public BodyDto()
        {
            ContentType = string.Empty;
            Content = string.Empty;
        }
    }

    public class MeetingDateTimeDto
    {
        [JsonPropertyName("dateTime")]
        public DateTime DateTime { get; set; }

        [JsonPropertyName("timeZone")]
        public string TimeZone { get; set; }

        public MeetingDateTimeDto()
        {
            DateTime = DateTime.MinValue;
            TimeZone = string.Empty;
        }
    }

    public class OrganizerDto
    {
        [JsonPropertyName("emailAddress")]
        public EmailAddressDto EmailAddress { get; set; }

        public OrganizerDto()
        {
            EmailAddress = new EmailAddressDto();
        }
    }

    public class EmailAddressDto
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("address")]
        public string Address { get; set; }

        public EmailAddressDto()
        {
            Name = string.Empty;
            Address = string.Empty;
        }
    }
}
