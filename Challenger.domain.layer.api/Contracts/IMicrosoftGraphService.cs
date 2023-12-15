using challenge.domain.layer.api.Domain.Dtos;
using challenge.domain.layer.api.Dtos;
using challenge.domain.layer.api.Models.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace challenge.domain.layer.api.Contracts
{
    public interface IMicrosoftGraphApiService
    {
        Task<IEnumerable<UserDto>> GetAllUsers();
        Task<IEnumerable<CalendarsDto>> GetCalendarByUser(string userId);
        Task<IEnumerable<EventDto>> GetAllEventsByCalendar(string calendarId);
        Task<IEnumerable<dynamic>> CreaetEvent(string userId, string calendarId, RecurringEvent body);
        Task<IEnumerable<dynamic>> DeleteEvent(string eventId);
        Task<IEnumerable<dynamic>> EditEvent(string eventId);
    }
}
