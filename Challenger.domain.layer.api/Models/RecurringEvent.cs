using System;
using System.Collections.Generic;

namespace challenge.domain.layer.api.Models
{
    public class RecurringEvent
    {
        public string Subject { get; set; }
        public ItemBody Body { get; set; }
        public DateTimeTimeZone Start { get; set; }
        public DateTimeTimeZone End { get; set; }
        public PatternedRecurrence Recurrence { get; set; }
        public Location Location { get; set; }
        public List<Attendee> Attendees { get; set; }
        public bool AllowNewTimeProposals { get; set; }
    }

    public class ItemBody
    {
        public BodyType ContentType { get; set; }
        public string Content { get; set; }
    }

    public class DateTimeTimeZone
    {
        public string DateTime { get; set; }
        public string TimeZone { get; set; }
    }

    public class PatternedRecurrence
    {
        public RecurrencePattern Pattern { get; set; }
        public RecurrenceRange Range { get; set; }
    }

    public class RecurrencePattern
    {
        public RecurrencePatternType Type { get; set; }
        public int Interval { get; set; }
        public List<DayOfWeekObject?> DaysOfWeek { get; set; }
    }

    public class RecurrenceRange
    {
        public RecurrenceRangeType Type { get; set; }
        public Date StartDate { get; set; }
        public Date EndDate { get; set; }
    }

    public class Location
    {
        public string DisplayName { get; set; }
    }

    public class Attendee
    {
        public EmailAddress EmailAddress { get; set; }
        public AttendeeType Type { get; set; }
    }

    public class EmailAddress
    {
        public string Address { get; set; }
        public string Name { get; set; }
    }

    public class Date
    {
        public DateTime Value { get; set; }

        public Date(DateTime date)
        {
            Value = date;
        }
    }

    public enum BodyType
    {
        Html
    }

    public enum RecurrencePatternType
    {
        Weekly
    }

    public enum RecurrenceRangeType
    {
        EndDate
    }

    public enum DayOfWeekObject
    {
        Monday,
        Tuesday,
        Wednesday,
        Thursday,
        Friday,
        Saturday,
        Sunday
    }

    public enum AttendeeType
    {
        Required
    }
}
