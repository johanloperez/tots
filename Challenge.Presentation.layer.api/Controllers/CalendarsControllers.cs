
using challenge.domain.layer.api.Contracts;
using challenge.domain.layer.api.Domain.Dtos;
using challenge.infrastructure.layer.api.HttpRequest;
using Microsoft.AspNetCore.Mvc;

namespace challenge.presentation.layer.api.Controllers
{
    public class CalendarsControllers : BaseController
    {
        private readonly IHttpService<dynamic> _iHttpGet;
        public CalendarsControllers(IHttpService<dynamic> iHttpGet)
        {
            _iHttpGet = iHttpGet;
        }

        [HttpGet("GetCalendars")]
        public async Task<ActionResult<CalendarsDto>> GetCalendars()
        {
            return Ok();
        }
    }
}
