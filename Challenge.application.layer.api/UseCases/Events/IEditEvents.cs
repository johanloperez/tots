using challenge.domain.layer.Models.Request;

namespace challenge.application.layer.UseCases.Events
{
    public interface IEditEvents
    {
        Task<string> Create(string userId, EditEventRequest request);
    }
}
