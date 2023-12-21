using challenge.domain.layer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace challenge.domain.layer.Models.Request
{
    public class CreateEventRequest
    {
        [JsonPropertyName("subject")]
        public string Subject { get; set; }

        [JsonPropertyName("body")]
        public Body Body { get; set; }

        [JsonPropertyName("start")]
        public MeetingDateTime Start { get; set; }

        [JsonPropertyName("end")]
        public MeetingDateTime End { get; set; }

        [JsonPropertyName("location")]
        public Location Location { get; set; }

        [JsonPropertyName("attendees")]
        public List<Attendee> Attendees { get; set; }

        [JsonPropertyName("transactionId")]
        public string TransactionId { get; set; }

        public CreateEventRequest()
        {
            Body = new Body();
            Start = new MeetingDateTime();
            End = new MeetingDateTime();
            Location = new Location();
            Attendees = new List<Attendee>();
            TransactionId = 
            Subject = string.Empty;
        }
    }
}
