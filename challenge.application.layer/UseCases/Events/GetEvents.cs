using challenge.application.layer.Services.Events;
using challenge.domain.layer.Dtos;

namespace challenge.application.layer.UseCases.Events
{
    public class GetEvents : IGetEvents
    {
        private readonly IEventService _eventService;

        public GetEvents(IEventService eventService)
        {
            _eventService = eventService;
        }

        public async Task<IEnumerable<EventDto>> GetAll(string userId)
        {
            return await _eventService.GetAll(userId);
        }
    }
}
