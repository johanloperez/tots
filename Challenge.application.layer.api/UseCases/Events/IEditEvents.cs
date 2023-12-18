using challenge.domain.layer.Models.Request;
using challenge.domain.layer.Models.Response;

namespace challenge.application.layer.UseCases.Events
{
    public interface IEditEvents
    {
        Task<EditEventResponse> Edit(string userId, string evenId, EditEventRequest request);
    }
}
