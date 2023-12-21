using challenge.application.layer.Services.Events;

namespace challenge.application.layer.UseCases.Events
{
    public class DeleteEvents : IDeleteEvents
    {
        private readonly IEventService _eventService;

        public DeleteEvents(IEventService eventService)
        {
            _eventService = eventService;
        }

        public async Task<string> DeleteById(string userId, string eventId)
        {
            return await _eventService.DeleteById(userId, eventId);
        }
    }
}
