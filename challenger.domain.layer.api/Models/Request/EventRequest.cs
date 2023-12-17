using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace challenge.domain.layer.Models.Request
{
    public class EventRequest
    {
        [JsonPropertyName("subject")]
        public string Subject { get; set; }

        [JsonPropertyName("body")]
        public MeetingBody Body { get; set; }

        [JsonPropertyName("start")]
        public MeetingDateTime Start { get; set; }

        [JsonPropertyName("end")]
        public MeetingDateTime End { get; set; }

        [JsonPropertyName("location")]
        public MeetingLocation Location { get; set; }

        [JsonPropertyName("attendees")]
        public List<MeetingAttendee> Attendees { get; set; }

        [JsonPropertyName("transactionId")]
        public string TransactionId { get; set; }

        public EventRequest()
        {
            Body = new MeetingBody();
            Start = new MeetingDateTime();
            End = new MeetingDateTime();
            Location = new MeetingLocation();
            Attendees = new List<MeetingAttendee>();
            TransactionId = 
            Subject = string.Empty;
        }
    }

    public class MeetingBody
    {
        [JsonPropertyName("contentType")]
        public string ContentType { get; set; }

        [JsonPropertyName("content")]
        public string Content { get; set; }

        public MeetingBody()
        {
            ContentType =
            Content = string.Empty;
        }
    }

    public class MeetingDateTime
    {
        [JsonPropertyName("dateTime")]
        public DateTime DateTime { get; set; }

        [JsonPropertyName("timeZone")]
        public string TimeZone { get; set; }

        public MeetingDateTime()
        {
            TimeZone = string.Empty;
        }
    }

    public class MeetingLocation
    {
        [JsonPropertyName("displayName")]
        public string DisplayName { get; set; }

        public MeetingLocation()
        {
            DisplayName = string.Empty;
        }
    }

    public class MeetingAttendee
    {
        [JsonPropertyName("emailAddress")]
        public MeetingEmailAddress EmailAddress { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }

        public MeetingAttendee()
        {
            EmailAddress = new MeetingEmailAddress();
            Type = string.Empty;
        }
    }

    public class MeetingEmailAddress
    {
        [JsonPropertyName("address")]
        public string Address { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        public MeetingEmailAddress()
        {
            Address = 
            Name = string.Empty;
        }
    }
}
