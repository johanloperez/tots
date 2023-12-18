using challenge.application.layer.Services.Events;
using challenge.application.layer.UseCases.Events;
using challenge.domain.layer.Dtos;
using challenge.domain.layer.Models.Request;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Net.Http.Headers;
using System.Reflection;

namespace challenge.presentation.layer.Controllers
{
    public class EventController : BaseController
    {
        private readonly IGetEvents _getEvents;
        private readonly ICreateEvents _createEvents;
        private readonly IEditEvents _editEvents;
        private readonly IDeleteEvents _deleteEvents;
        public EventController(
            IGetEvents getEvents,
            ICreateEvents createEvents,
            IEditEvents editEvents,
            IDeleteEvents deleteEvents)
        {   
            _getEvents = getEvents;
            _createEvents = createEvents;
            _deleteEvents = deleteEvents;
            _editEvents = editEvents;
        }

        [HttpPost("CreateEvents/user/{userId}")]
        public async Task<ActionResult<EventDto>> CreateEvents([FromQuery] string userId, [FromBody] CreateEventRequest request)
        {
            var result = await _createEvents.Create(userId,request);
            return Ok(result);
        }

        [HttpGet("GetListEvents/user/{userId}")]
        public async Task<ActionResult<IEnumerable<EventDto>>> GetListEvents(string userId)
        {
            var result = await _getEvents.GetAll(userId);
            return Ok(result);
        }

        [HttpDelete("DeleteEvent/user/{userId}/event/{eventId}")]
        public async Task<ActionResult> DeleteEvent(string userId, string eventId)
        {
            var result = await _deleteEvents.DeleteById(userId, eventId);
            return Ok(result);
        }

        [HttpPatch("UpdateEvent/user/{userId}/event/{eventId}")]
        public async Task<ActionResult> UpdateEvent(string userId, string eventId)
        {
            var result = await _deleteEvents.DeleteById(userId, eventId);
            return Ok(result);
        }
    }
}