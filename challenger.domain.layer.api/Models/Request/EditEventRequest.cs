using challenge.domain.layer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace challenge.domain.layer.Models.Request
{
#nullable enable
    public class EditEventRequest
    {
        [JsonPropertyName("originalStartTimeZone")]
        public string OriginalStartTimeZone { get; set; }

        [JsonPropertyName("originalEndTimeZone")]
        public string OriginalEndTimeZone { get; set; }

        [JsonPropertyName("responseStatus")]
        public ResponseStatus ResponseStatus { get; set; }

        [JsonPropertyName("recurrence")]
        public object? Recurrence { get; set; }

        [JsonPropertyName("reminderMinutesBeforeStart")]
        public int ReminderMinutesBeforeStart { get; set; }

        [JsonPropertyName("isOnlineMeeting")]
        public bool IsOnlineMeeting { get; set; }

        [JsonPropertyName("onlineMeetingProvider")]
        public string OnlineMeetingProvider { get; set; }

        [JsonPropertyName("isReminderOn")]
        public bool IsReminderOn { get; set; }

        [JsonPropertyName("hideAttendees")]
        public bool HideAttendees { get; set; }

        [JsonPropertyName("categories")]
        public List<string> Categories { get; set; }

        public EditEventRequest()
        {
            Recurrence = new object();
            OriginalStartTimeZone = string.Empty;
            OriginalEndTimeZone = string.Empty;
            ResponseStatus = new ResponseStatus();
            ReminderMinutesBeforeStart = 0;
            IsOnlineMeeting = false;
            OnlineMeetingProvider = string.Empty;
            IsReminderOn = false;
            HideAttendees = false;
            Categories = new List<string>() { "Red category"};
        }
    }
}
