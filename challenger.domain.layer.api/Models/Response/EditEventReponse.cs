using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;
using challenge.domain.layer.Entities;

namespace challenge.domain.layer.Models.Response
{
    public class EditEventResponse
    {
        [JsonPropertyName("originalStartTimeZone")]
        public string OriginalStartTimeZone { get; set; }

        [JsonPropertyName("originalEndTimeZone")]
        public string OriginalEndTimeZone { get; set; }

        [JsonPropertyName("responseStatus")]
        public ResponseStatus ResponseStatus { get; set; }

        [JsonPropertyName("recurrence")]
        public object Recurrence { get; set; }

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

        [JsonPropertyName("onlineMeeting")]
        public OnlineMeeting OnlineMeeting { get; set; }

        public EditEventResponse()
        {
            OriginalStartTimeZone = string.Empty;
            OriginalEndTimeZone = string.Empty;
            ResponseStatus = new ResponseStatus();
            Recurrence = new object();
            ReminderMinutesBeforeStart = 0;
            IsOnlineMeeting = false;
            OnlineMeetingProvider = string.Empty;
            IsReminderOn = false;
            HideAttendees = false;
            OnlineMeeting = new OnlineMeeting();
        }
    }

    public class OnlineMeeting
    {
        [JsonPropertyName("joinUrl")]
        public string JoinUrl { get; set; }

        [JsonPropertyName("conferenceId")]
        public string ConferenceId { get; set; }

        [JsonPropertyName("tollNumber")]
        public string TollNumber { get; set; }

        public OnlineMeeting()
        {
            JoinUrl = string.Empty;
            ConferenceId = string.Empty;
            TollNumber = string.Empty;
        }
    }
}
