using challenge.infrastructure.layer.api.HttpRequest;
using challenge.domain.layer.api.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using challenge.domain.layer.api.Models.Options;
using Microsoft.Extensions.Options;
using System.Text.Json;
using Challenge.infrastructure.layer.api.Helpers;
using challenge.domain.layer.api.Models.Request;
using challenge.domain.layer.api.Domain.Dtos;
using challenge.domain.layer.api.Dtos;
using challenge.domain.layer.api.Entities;
using challenge.domain.layer.api;
using System.Net.Http.Headers;
using challenge.domain.layer.api.Contracts;
using challenge.domain.layer.Models.Response;
using challenge.domain.layer.Models.Options;
using System.Web;
using System.Text.Json.Serialization;
using System.Reflection;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;

namespace challenge.infrastructure.layer.api.ExternalApis.MicrosoftGraphApi
{
    public class MicrosoftGraphApiService : IMicrosoftGraphApiService
    {
        private readonly IHttpService<TokenResponse> _httpServiceToken;
        private readonly IHttpService<dynamic> _httpServiceTokenDelegate;
        private readonly IHttpService<GetUsersResponse> _httpServiceUser;
        private readonly IHttpService<GetCalendarResponse> _httpServiceCalendar;
        private readonly IUserMapper _userMapper;
        private readonly Token _tokenBody;
        private readonly Urls _urls;

        public MicrosoftGraphApiService(
            IHttpService<GetCalendarResponse> httpServiceCalendar,
            IHttpService<TokenResponse> httpServiceToken, 
            IHttpService<GetUsersResponse> httpServiceUser,
            IHttpService<dynamic> httpServiceTokenDelegate,
            IOptions<Token> tokenBody, 
            IOptions<Urls> urls, 
            IUserMapper userMapper,
            IOptions<GetTokenDelegate> tokenDelegateBody)
        {
            _httpServiceToken = httpServiceToken;
            _httpServiceUser = httpServiceUser;
            _userMapper = userMapper;
            _tokenBody = tokenBody.Value;
            _urls = urls.Value;
            _httpServiceCalendar = httpServiceCalendar;
            _httpServiceTokenDelegate = httpServiceTokenDelegate;

            //if (HttpContext.Request.Headers.TryGetValue("Authorization", out StringValues authHeaderValue))
            //{
            //    string token = authHeaderValue.ToString().Replace("Bearer ", string.Empty);
            //    // Hacer algo con el token
            //    return Ok($"Token recibido: {token}");
            //}
        }

        public async Task<IEnumerable<dynamic>> CreaetEvent(string userId, string calendarId, RecurringEvent body)
        {

            var token = "";
            var jsonContent = JsonSerializer.Serialize(body);
            var requestBody = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            var auth = new AuthenticationHeaderValue("Bearer", token);

            var graphResult = await _httpServiceUser.Post("graph", requestBody, auth);

            throw new NotImplementedException();
        }

        public async Task<IEnumerable<dynamic>> DeleteEvent(string eventId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<dynamic>> EditEvent(string eventId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<EventDto>> GetAllEventsByCalendar(string calendarId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<UserDto>> GetAllUsers()
        {

            var token = "";
            var users = await _httpServiceUser.Get("users", new AuthenticationHeaderValue("Bearer", token));
            var result = new List<UserDto>();

            foreach (var user in users.Value)
            {
                result.Add(_userMapper.MapToDto(user));
            }

            return result;
        }

        public async Task<CalendarsDto> GetCalendarByUser(string user)
        {
            var token = "";
            var uri = _urls.GetCalendars.Replace("{user}", user);
            var users = await _httpServiceCalendar.Get("calendars", new AuthenticationHeaderValue("Bearer", token),uri);
            var result = new CalendarsDto();

            return result;
        }

        public async Task<string> RequestAccessToken(string code)
        {
            _tokenBody.Code = code; 

            if (CustomValidations.AnyPropertyNullOrEmpty(_tokenBody))
                throw new Exception("Faltan parametros necesarios para solicitar el token.");

            var json = JsonSerializer.Serialize(_tokenBody);
            var dictionary = JsonSerializer.Deserialize<Dictionary<string, string>>(json);

            if (dictionary is null)
                throw new Exception("Error a deserializar el json del objecto de los parametros para solicitar el token.");

            var body = new FormUrlEncodedContent(dictionary);

            var JsonContent = await _httpServiceToken.Post("token", body);

            if (JsonContent.AccessToken is null)
                throw new Exception("código inválido");

            return JsonContent.AccessToken;
        }
    }
}
