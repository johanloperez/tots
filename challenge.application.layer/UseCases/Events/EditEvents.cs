using challenge.application.layer.Services.Events;
using challenge.domain.layer.Models.Request;
using challenge.domain.layer.Models.Response;

namespace challenge.application.layer.UseCases.Events
{
    public class EditEvents : IEditEvents
    {
        private readonly IEventService _eventService;

        public EditEvents(IEventService eventService)
        {
            _eventService = eventService;
        }

        public async Task<EditEventResponse> Edit(string userId, string evenId, EditEventRequest request)
        {
            return await _eventService.EditEvent(userId, evenId,request);
        }
    }
}
