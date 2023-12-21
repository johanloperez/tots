using challenge.application.layer.Services.Events;
using challenge.domain.layer.Dtos;
using challenge.domain.layer.Models.Request;

namespace challenge.application.layer.UseCases.Events
{
    public class CreateEvents : ICreateEvents
    {
        private readonly IEventService _eventService;

        public CreateEvents(IEventService eventService)
        {
            _eventService = eventService;
        }

        public async Task<EventDto> Create(string userId, CreateEventRequest request)
        {
            return await _eventService.CreateEvent(userId, request);
        }
    }
}
