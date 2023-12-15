
using challenge.application.layer.api.Services.Calendars;
using challenge.application.layer.api.Services.Users;
using challenge.domain.layer.api.Contracts;
using challenge.domain.layer.api.Domain.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace challenge.presentation.layer.api.Controllers
{
    public class CalendarsControllers : BaseController
    {
        private readonly ICalendarServices _calendarService;

        public CalendarsControllers(ICalendarServices calendarService)
        {
            _calendarService = calendarService;
        }

        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpGet("GetCalendar")]
        public async Task<ActionResult<CalendarsDto>> GetUsers([FromQuery] string user)
        {
            return Ok(await _calendarService.GetCalendar(user));
        }
    }
}
