using challenge.domain.layer.Contracts;
using challenge.domain.layer.Dtos;
using challenge.domain.layer.Models.Request;
using challenge.domain.layer.Models.Response;

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

        public async Task<EditEventResponse> EditEvent(string userId, string evenId, EditEventRequest request)
        {
            return await _mgApiService.EditEvent(userId, evenId, request);
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
