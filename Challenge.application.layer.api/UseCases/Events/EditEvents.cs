using challenge.application.layer.Services.Events;
using challenge.domain.layer.Models.Request;

namespace challenge.application.layer.UseCases.Events
{
    public class EditEvents : IEditEvents
    {
        private readonly IEventService _eventService;

        public EditEvents(IEventService eventService)
        {
            _eventService = eventService;
        }

        public async Task<string> Create(string userId, EditEventRequest request)
        {
            return await _eventService.EditEvent(userId, request);
        }
    }
}
