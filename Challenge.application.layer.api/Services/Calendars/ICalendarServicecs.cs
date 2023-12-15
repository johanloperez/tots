using challenge.domain.layer.api.Domain.Dtos;

namespace challenge.application.layer.api.Services.Calendars
{
    public interface ICalendarServices
    {
        Task<CalendarsDto> GetCalendar(string user);
    }
}
