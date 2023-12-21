using challenge.domain.layer.Dtos;

namespace challenge.application.layer.UseCases.Events
{
    public interface IGetEvents
    {
        Task<IEnumerable<EventDto>> GetAll(string userId);
    }
}
