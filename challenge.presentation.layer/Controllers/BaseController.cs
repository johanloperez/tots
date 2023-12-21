using Microsoft.AspNetCore.Mvc;

namespace challenge.presentation.layer.Controllers
{
    [ApiController]
    [Route(BasePath + "/[controller]")]
    public abstract class BaseController : ControllerBase
    {
        protected const string BasePath = "api";
    }
}
