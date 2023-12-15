using challenge.domain.layer.api.Contracts;
using challenge.domain.layer.api.Domain.Dtos;

namespace challenge.application.layer.api.Services.Calendars
{
    public class CalendarService : ICalendarServices
    {
        private readonly IMicrosoftGraphApiService _mgApiService;

        public CalendarService(IMicrosoftGraphApiService mgApiService)
        {
            _mgApiService = mgApiService;
        }

        public async Task<CalendarsDto> GetCalendar(string user)
        {
            return await _mgApiService.GetCalendarByUser(user);
        }
    }
}
