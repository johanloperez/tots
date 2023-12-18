using challenge.infrastructure.layer.HttpRequest;
using challenge.domain.layer.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using challenge.domain.layer.Models.Options;
using Microsoft.Extensions.Options;
using System.Text.Json;
using Challenge.infrastructure.layer.Helpers;
using challenge.domain.layer.Models.Request;
using challenge.domain.layer.Dtos;
using challenge.domain.layer.Dtos;
using challenge.domain.layer.Entities;
using challenge.domain.layer;
using System.Net.Http.Headers;
using challenge.domain.layer.Contracts;
using System.Web;
using System.Text.Json.Serialization;
using System.Reflection;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;
using challenge.infrastructure.layer.AutoMapper;

namespace challenge.infrastructure.layer.ExternalApis.MicrosoftGraphApi
{
    public class MicrosoftGraphApiService : IMicrosoftGraphApiService
    {
        private readonly IHttpService<GetTokenResponse> _httpServiceGetToken;
        private readonly IHttpService<dynamic> _httpServiceDeleteEvent;
        private readonly IHttpService<GetUsersResponse> _httpServiceGetUser;
        private readonly IHttpService<GetEventResponse> _httpServiceGetEvent;
        private readonly IHttpService<Event> _httpServiceCreateEvent;
        private readonly IUserMapper _userMapper;
        private readonly IEventMapper _eventMapper;
        private readonly Token _tokenBody;
        private readonly Urls _urls;

        public MicrosoftGraphApiService(
            IHttpService<GetTokenResponse> httpServiceGetToken, 
            IHttpService<GetUsersResponse> httpServiceGetUser,
            IHttpService<GetEventResponse> httpServiceGetEvent,
            IHttpService<Event> httpServiceCreateEvent,
            IHttpService<dynamic> httpServiceDeleteEvent,
            IOptions<Token> tokenBody, 
            IOptions<Urls> urls, 
            IUserMapper userMapper,
            IEventMapper eventMapper,
            IOptions<GetTokenDelegate> tokenDelegateBody)
        {
            _httpServiceGetToken = httpServiceGetToken;
            _httpServiceGetUser = httpServiceGetUser;
            _userMapper = userMapper;
            _tokenBody = tokenBody.Value;
            _urls = urls.Value;
            _httpServiceGetEvent = httpServiceGetEvent;
            _eventMapper = eventMapper;
            _httpServiceDeleteEvent = httpServiceDeleteEvent;
            _httpServiceCreateEvent = httpServiceCreateEvent;
        }

        public async Task<EventDto> CreateEvent(string userId, CreateEventRequest request)
        {
            var token = RequestAccessToken();
            var uri = _urls.GetEvents.Replace("{userId}", userId);

            var json = JsonSerializer.Serialize(request);

            var body = new StringContent(json, Encoding.UTF8,"application/json" );

            var events = await _httpServiceCreateEvent.Post("events", body, new AuthenticationHeaderValue("Bearer", token.Result), uri);
            var result = _eventMapper.MapToDto(events);

            return result;
        }

        public async Task<string> DeleteEventById(string userId, string eventId)
        {
            var token = RequestAccessToken();
            var uri = _urls.DeleteEvents.Replace("{userId}", userId).Replace("{eventId}",eventId);
            var delete = await _httpServiceDeleteEvent.Delete("deleteEvents", new AuthenticationHeaderValue("Bearer", token.Result), uri);

            return delete ? "Ok":"Failed";
        }

        public async Task<string> EditEvent(string userId, EditEventRequest request)
        {
            throw new NotImplementedException();

            //var token = RequestAccessToken();
            //var uri = _urls.GetEvents.Replace("{userId}", userId);

            //var json = JsonSerializer.Serialize(request);

            //var body = new StringContent(json, Encoding.UTF8, "application/json");

            //var events = await _httpServiceCreateEvent.Post("events", body, new AuthenticationHeaderValue("Bearer", token.Result), uri);
            //var result = _eventMapper.MapToDto(events);

            //return result;
        }

        public async Task<IEnumerable<EventDto>> GetAllEvents(string user)
        {
                var token = RequestAccessToken();
                var uri = _urls.GetEvents.Replace("{userId}", user);
                var events = await _httpServiceGetEvent.Get("events", new AuthenticationHeaderValue("Bearer", token.Result), uri);
                var result = new List<EventDto>();

                foreach (var item in events.Value)
                {
                    result.Add(_eventMapper.MapToDto(item));
                }

                return result;

        }

        public async Task<IEnumerable<UserDto>> GetAllUsers()
        {

            var token = RequestAccessToken();
            var users = await _httpServiceGetUser.Get("users", new AuthenticationHeaderValue("Bearer", token.Result));
            var result = new List<UserDto>();

            foreach (var user in users.Value)
            {
                result.Add(_userMapper.MapToDto(user));
            }

            return result;
        }


        public async Task<string> RequestAccessToken()
        {
            if (CustomValidations.AnyPropertyNullOrEmpty(_tokenBody))
                throw new Exception("Faltan parametros necesarios para solicitar el token.");

            var json = JsonSerializer.Serialize(_tokenBody);
            var dictionary = JsonSerializer.Deserialize<Dictionary<string, string>>(json);

            if (dictionary is null)
                throw new Exception("Error a deserializar el json del objecto de los parametros para solicitar el token.");

            var body = new FormUrlEncodedContent(dictionary);

            var JsonContent = await _httpServiceGetToken.Post("token", body);

            if (JsonContent.AccessToken is null)
                throw new Exception("código inválido");

            return JsonContent.AccessToken;
        }

        public Task<string> RequestAccessToken(string code)
        {
            //_tokenBody.Code = code; 
            throw new NotImplementedException();
        }
    }
}
