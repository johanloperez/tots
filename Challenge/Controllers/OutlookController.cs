using Challenge.bootstrapper.layer.api.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Graph;
using Microsoft.Graph.Models;
using Microsoft.Identity.Client;

namespace Challenge.Controllers
{
    public class OutlookController : BaseController
    {
        public OutlookController()
        {
        }

        [HttpGet("CreateEvents")]
        public async Task<IActionResult> CreateEvents()
        {
            Dictionary<string, string> bodyData = new()
            {
                {"grant_type",_tokenSettings.GrantType },
                {"code",code },
                {"redirect_uri",redirectUri },
                {"client_id",_tokenSettings.ClientId },
                {"client_secret",_tokenSettings.ClientSecret }
            };

            var body = new FormUrlEncodedContent(bodyData);

            Ticket JsonContent = await _ipost.Request("token", body);

            if (JsonContent.access_token is null)
            {
                throw new ShowException("código inválido", 500);
            }

            JsonContent.SetName("name");

            TicketDC ticketDC = _mapper.Map<TicketDC>(JsonContent);

            return Ok();
        }
    }
}