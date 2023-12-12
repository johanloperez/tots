using Microsoft.AspNetCore.Mvc;

namespace Challenge.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OutlookController : ControllerBase
    {
        public OutlookController()
        {
        }

        [HttpGet(Name = "CreateEvents")]
        public IActionResult CreateEvents()
        {
            return Ok();
        }
    }
}