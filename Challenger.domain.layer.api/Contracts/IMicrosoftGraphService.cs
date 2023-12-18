using challenge.domain.layer.Dtos;
using challenge.domain.layer.Dtos;
using challenge.domain.layer.Models.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace challenge.domain.layer.Contracts
{
    public interface IMicrosoftGraphApiService
    {
        Task<IEnumerable<UserDto>> GetAllUsers();
        Task<string> RequestAccessToken(string code);
        Task<string> RequestAccessToken();
        Task<IEnumerable<EventDto>> GetAllEvents(string user);
        Task<EventDto> CreateEvent(string userId, CreateEventRequest request);
        Task<string> DeleteEventById(string userId, string eventId);
        Task<string> EditEvent(string userId, EditEventRequest request);
    }
}
