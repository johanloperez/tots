using challenge.domain.layer.Dtos;
using challenge.domain.layer.Models.Request;
using challenge.domain.layer.Models.Response;

namespace challenge.application.layer.Services.Events
{
    public interface IEventService
    {
        Task<IEnumerable<EventDto>> GetAll(string userId);
        Task<string> DeleteById(string userId, string eventId);
        Task<EventDto> CreateEvent(string userId, CreateEventRequest request);
        Task<EditEventResponse> EditEvent(string userId, string eventId, EditEventRequest request);
    }
}
