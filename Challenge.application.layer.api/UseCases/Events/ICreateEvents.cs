using challenge.domain.layer.Dtos;
using challenge.domain.layer.Models.Request;

namespace challenge.application.layer.UseCases.Events
{
    public interface ICreateEvents
    {
        Task<EventDto> Create(string userId, CreateEventRequest request);
    }
}
