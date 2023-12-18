using challenge.domain.layer.Contracts;
using challenge.domain.layer.Dtos;
using challenge.domain.layer.Models.Request;

namespace challenge.application.layer.Services.Events
{
    public class EventService : IEventService
    {
        private readonly IMicrosoftGraphApiService _mgApiService;

        public EventService(IMicrosoftGraphApiService mgApiService)
        {
            _mgApiService = mgApiService;
        }

        public async Task<EventDto> CreateEvent(string userId, CreateEventRequest request)
        {
            return await _mgApiService.CreateEvent(userId,request);
        }

        public async Task<string> EditEvent(string userId, EditEventRequest request)
        {
            return await _mgApiService.EditEvent(userId, request);
        }

        public async Task<IEnumerable<EventDto>> GetAll(string userId)
        {
            return await _mgApiService.GetAllEvents(userId);
        }

        public async Task<string> DeleteById(string userId, string evenId)
        {
            return await _mgApiService.DeleteEventById(userId ,evenId);
        }
    }
}
