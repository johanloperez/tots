using Microsoft.AspNetCore.Mvc;

namespace Challenge.bootstrapper.layer.api.Controllers
{
    [ApiController]
    [Route(BasePath + "/[controller]")]
    public abstract class BaseController : ControllerBase
    {
        protected const string BasePath = "api";
    }
}
