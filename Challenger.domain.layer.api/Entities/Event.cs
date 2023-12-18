using System.Text.Json.Serialization;

namespace challenge.domain.layer.Entities
{
    public class Event
    {
        [JsonPropertyName("@odata.etag")]
        public string ODataEtag { get; set; }

        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("createdDateTime")]
        public DateTime CreatedDateTime { get; set; }

        [JsonPropertyName("lastModifiedDateTime")]
        public DateTime LastModifiedDateTime { get; set; }

        [JsonPropertyName("changeKey")]
        public string ChangeKey { get; set; }

        [JsonPropertyName("categories")]
        public List<string> Categories { get; set; }

        [JsonPropertyName("transactionId")]
        public string TransactionId { get; set; }

        [JsonPropertyName("originalStartTimeZone")]
        public string OriginalStartTimeZone { get; set; }

        [JsonPropertyName("originalEndTimeZone")]
        public string OriginalEndTimeZone { get; set; }

        [JsonPropertyName("iCalUId")]
        public string ICalUId { get; set; }

        [JsonPropertyName("reminderMinutesBeforeStart")]
        public int ReminderMinutesBeforeStart { get; set; }

        [JsonPropertyName("isReminderOn")]
        public bool IsReminderOn { get; set; }

        [JsonPropertyName("hasAttachments")]
        public bool HasAttachments { get; set; }

        [JsonPropertyName("subject")]
        public string Subject { get; set; }

        [JsonPropertyName("bodyPreview")]
        public string BodyPreview { get; set; }

        [JsonPropertyName("importance")]
        public string Importance { get; set; }

        [JsonPropertyName("sensitivity")]
        public string Sensitivity { get; set; }

        [JsonPropertyName("isAllDay")]
        public bool IsAllDay { get; set; }

        [JsonPropertyName("isCancelled")]
        public bool IsCancelled { get; set; }

        [JsonPropertyName("isOrganizer")]
        public bool IsOrganizer { get; set; }

        [JsonPropertyName("responseRequested")]
        public bool ResponseRequested { get; set; }

        [JsonPropertyName("seriesMasterId")]
        public string SeriesMasterId { get; set; }

        [JsonPropertyName("showAs")]
        public string ShowAs { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("webLink")]
        public string WebLink { get; set; }

        [JsonPropertyName("onlineMeetingUrl")]
        public string OnlineMeetingUrl { get; set; }

        [JsonPropertyName("isOnlineMeeting")]
        public bool IsOnlineMeeting { get; set; }

        [JsonPropertyName("onlineMeetingProvider")]
        public string OnlineMeetingProvider { get; set; }

        [JsonPropertyName("allowNewTimeProposals")]
        public bool AllowNewTimeProposals { get; set; }

        [JsonPropertyName("occurrenceId")]
        public string OccurrenceId { get; set; }

        [JsonPropertyName("isDraft")]
        public bool IsDraft { get; set; }

        [JsonPropertyName("hideAttendees")]
        public bool HideAttendees { get; set; }

        [JsonPropertyName("responseStatus")]
        public ResponseStatus ResponseStatus { get; set; }

        [JsonPropertyName("body")]
        public Body Body { get; set; }

        [JsonPropertyName("start")]
        public MeetingDateTime Start { get; set; }

        [JsonPropertyName("end")]
        public MeetingDateTime End { get; set; }

        [JsonPropertyName("location")]
        public Location Location { get; set; }

        [JsonPropertyName("locations")]
        public List<Location> Locations { get; set; }

        [JsonPropertyName("recurrence")]
        public object Recurrence { get; set; }

        [JsonPropertyName("attendees")]
        public List<Attendee> Attendees { get; set; }

        [JsonPropertyName("organizer")]
        public Organizer Organizer { get; set; }

        [JsonPropertyName("onlineMeeting")]
        public object OnlineMeeting { get; set; }

        [JsonPropertyName("calendar@odata.associationLink")]
        public string CalendarODataAssociationLink { get; set; }

        [JsonPropertyName("calendar@odata.navigationLink")]
        public string CalendarODataNavigationLink { get; set; }

        public Event()
        {
            OnlineMeeting = new object();
            Recurrence = new object();
            Body = new Body();
            Start = new MeetingDateTime();
            End = new MeetingDateTime();
            Location = new Location();
            Locations = new List<Location>();
            Attendees = new List<Attendee>();
            Organizer = new Organizer();
            Categories = new List<string>();
            ResponseStatus = new ResponseStatus();
            CreatedDateTime = DateTime.MinValue;
            LastModifiedDateTime = DateTime.MinValue;
            ODataEtag =
            Id =
            ChangeKey =
            TransactionId =
            OriginalStartTimeZone =
            OriginalEndTimeZone =
            ICalUId =
            Subject =
            BodyPreview =
            Importance =
            Sensitivity =
            SeriesMasterId =
            ShowAs =
            Type =
            WebLink =
            OnlineMeetingUrl =
            OnlineMeetingProvider =
            OccurrenceId =
            CalendarODataAssociationLink =
            CalendarODataNavigationLink = string.Empty;
        }
    }

    public class ResponseStatus
    {
        [JsonPropertyName("response")]
        public string Response { get; set; }

        [JsonPropertyName("time")]
        public DateTime Time { get; set; }

        public ResponseStatus()
        {
            Response = "none";
            Time = DateTime.MinValue;
        }
    }

    public class Body
    {
        [JsonPropertyName("contentType")]
        public string ContentType { get; set; }

        [JsonPropertyName("content")]
        public string Content { get; set; }

        public Body()
        {
            ContentType = string.Empty;
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

    public class Location
    {
        [JsonPropertyName("displayName")]
        public string DisplayName { get; set; }

        [JsonPropertyName("locationType")]
        public string LocationType { get; set; }

        [JsonPropertyName("uniqueIdType")]
        public string UniqueIdType { get; set; }

        [JsonPropertyName("address")]
        public object Address { get; set; }

        [JsonPropertyName("coordinates")]
        public object Coordinates { get; set; }

        public Location()
        {
            DisplayName = string.Empty;
            LocationType = string.Empty;
            UniqueIdType = string.Empty;
            Address = new object();
            Coordinates = new object();
        }
    }

    public class Organizer
    {
        [JsonPropertyName("emailAddress")]
        public EmailAddress EmailAddress { get; set; }

        public Organizer()
        {
            EmailAddress = new EmailAddress();
        }
    }

    public class EmailAddress
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("address")]
        public string Address { get; set; }

        public EmailAddress()
        {
            Name = string.Empty;
            Address = string.Empty;
        }
    }

    public class Attendee
    {
        [JsonPropertyName("emailAddress")]
        public EmailAddress EmailAddress { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }

        public Attendee()
        {
            EmailAddress = new EmailAddress();
            Type = string.Empty;
        }
    }
}
