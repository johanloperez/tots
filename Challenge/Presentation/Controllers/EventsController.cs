using challenge.bootstrapper.layer.api.Domain.Models.Request;
using Challenge.bootstrapper.layer.api.Application;
using Challenge.bootstrapper.layer.api.Controllers;
using Challenge.bootstrapper.layer.api.Infrastructure.HttpRequest.Get;
using Challenge.bootstrapper.layer.api.Infrastructure.HttpRequest.Post;
using Challenge.bootstrapper.layer.api.Models.Options;
using Challenge.bootstrapper.layer.api.Models.Response;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

using Microsoft.Identity.Client;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text;
using System.Text.Json;

namespace Challenge.Controllers
{
    public class OutlookController : BaseController
    {
        private readonly IHttpPost<dynamic> _ipostCreateEvent;
        private readonly IHttpGet<dynamic> _iget;
        private readonly IRequestToken _requestToken;
        public OutlookController(IHttpPost<dynamic> ipostCreateEvent, IHttpGet<dynamic> iget, IRequestToken requestToken)
        {
            _ipostCreateEvent = ipostCreateEvent;
            _iget = iget;
            _requestToken = requestToken;
        }

        [HttpPost("CreateEvents")]
        public async Task<IActionResult> CreateEvents([FromBody] RecurringEventRequest request)
        {
            var bodyEvent = new RecurringEventRequest()
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

            var token = await _requestToken.Get();
            var jsonContent = JsonSerializer.Serialize(request);
            var requestBody = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            var graphResult = await _ipostCreateEvent.Request("graph", requestBody, new AuthenticationHeaderValue("Bearer", token));

            return Ok();
        }
        

    }
}