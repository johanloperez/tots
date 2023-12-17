using challenge.domain.layer.Dtos;
using challenge.domain.layer.Models.Request;

namespace challenge.application.layer.Services.Events
{
    public interface IEventService
    {
        Task<IEnumerable<EventDto>> GetAll(string userId);
        Task<string> DeleteById(string userId, string eventId);
        Task<EventDto> CreateEvent(string userId, EventRequest request);
    }
}
