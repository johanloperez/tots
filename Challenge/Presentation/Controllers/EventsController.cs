using Challenge.bootstrapper.layer.api.Controllers;
using Challenge.bootstrapper.layer.api.Infrastructure.HttpRequest.Get;
using Challenge.bootstrapper.layer.api.Infrastructure.HttpRequest.Post;
using Challenge.bootstrapper.layer.api.Models;
using Challenge.bootstrapper.layer.api.Models.Options;
using Challenge.bootstrapper.layer.api.Models.Response;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

using Microsoft.Identity.Client;
using System.Net.Http.Headers;
using System.Reflection;

namespace Challenge.Controllers
{
    public class OutlookController : BaseController
    {
        private readonly IHttpPost<TokenResponse> _ipost;
        private readonly IHttpGet<dynamic> _iget;
        private readonly Token _tokenOptions;
        public OutlookController(IHttpPost<TokenResponse> ipost, IHttpGet<dynamic> iget, IOptions<Token> tokenOptions)
        {
            _ipost = ipost;
            _iget = iget;
            _tokenOptions = tokenOptions.Value;

        }

        [HttpGet("CreateEvents")]
        public async Task<IActionResult> CreateEvents()
        {
            Dictionary<string, string> bodyData = new()
            {
                {"grant_type",_tokenOptions.GrantType },
                {"client_id",_tokenOptions.ClientId },
                {"client_secret",_tokenOptions.ClientSecret },
                {"scope",_tokenOptions.Scope },
                {"tenant",_tokenOptions.Tenant },
            };

            var bodyToken = new FormUrlEncodedContent(bodyData);

            var JsonContent = await _ipost.Request("token", bodyToken);

            if (JsonContent.access_token is null)
                throw new Exception("código inválido");

            var bodyEvent = new RecurringEvent()
            {
                Subject = "Let's go for lunch",
                Body = new ItemBody
                {
                    ContentType = BodyType.Html,
                    Content = "Does noon time work for you?",
                },
                Start = new DateTimeTimeZone
                {
                    DateTime = "2017-09-04T12:00:00",
                    TimeZone = "Pacific Standard Time",
                },
                End = new DateTimeTimeZone
                {
                    DateTime = "2017-09-04T14:00:00",
                    TimeZone = "Pacific Standard Time",
                },
                Recurrence = new PatternedRecurrence
                {
                    Pattern = new RecurrencePattern
                    {
                        Type = RecurrencePatternType.Weekly,
                        Interval = 1,
                        DaysOfWeek = new List<DayOfWeekObject?>
            {
                DayOfWeekObject.Monday,
            },
                    },
                    Range = new RecurrenceRange
                    {
                        Type = RecurrenceRangeType.EndDate,
                        StartDate = new Date(DateTime.Parse("2017-09-04")),
                        EndDate = new Date(DateTime.Parse("2017-12-31")),
                    },
                },
                Location = new Location
                {
                    DisplayName = "Harry's Bar",
                },
                Attendees = new List<Attendee>
    {
        new Attendee
        {
            EmailAddress = new EmailAddress
            {
                Address = "AdeleV@contoso.onmicrosoft.com",
                Name = "Adele Vance",
            },
            Type = AttendeeType.Required,
        },
    },
                AllowNewTimeProposals = true,
            };
            Dictionary<string, string> eventDictionary = ConvertToDictionary(bodyEvent);
            var requestBody = new FormUrlEncodedContent(eventDictionary);


            var graphResult = await _ipost.Request("graph", requestBody, new AuthenticationHeaderValue("Bearer", JsonContent.access_token));

            return Ok();
        }

        private static Dictionary<string, string> ConvertToDictionary(object obj)
        {
            if (obj is null)
                throw new ArgumentNullException(nameof(obj));

            return obj.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public)
                .ToDictionary(prop => prop.Name, prop => prop.GetValue(obj).ToString());
        }
    }
}