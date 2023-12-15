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

namespace challenge.infrastructure.layer.api.ExternalApis.MicrosoftGraphApi
{
    public class MicrosoftGraphApiService : IMicrosoftGraphApiService
    {
        private readonly IHttpService<TokenResponse> _httpServiceToken;
        private readonly IHttpService<GetUsersResponse> _httpServiceUser;
        private readonly Token _tokenBody;

        public MicrosoftGraphApiService(IHttpService<TokenResponse> httpServiceToken, IHttpService<GetUsersResponse> httpServiceUser, IOptions<Token> tokenBody)
        {
            _httpServiceToken = httpServiceToken;
            _httpServiceUser = httpServiceUser; 
            _tokenBody = tokenBody.Value;
        }

        public async Task<IEnumerable<dynamic>> CreaetEvent(string userId, string calendarId, RecurringEvent body)
        {

            var token = RequestAccessToken();
            var jsonContent = JsonSerializer.Serialize(body);
            var requestBody = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            var auth = new AuthenticationHeaderValue("Bearer", token.Result);

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
            var token = RequestAccessToken();
            var users = await _httpServiceUser.Get("users", new AuthenticationHeaderValue("Bearer", token.Result));
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<CalendarsDto>> GetCalendarByUser(string userId)
        {
            throw new NotImplementedException();
        }

        private async Task<string> RequestAccessToken()
        {
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
