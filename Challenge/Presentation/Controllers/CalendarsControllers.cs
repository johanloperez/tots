using Challenge.bootstrapper.layer.api.Infrastructure.HttpRequest.Get;

namespace Challenge.bootstrapper.layer.api.Controllers
{
    public class CalendarsControllers : BaseController
    {
        private readonly IHttpGet<dynamic> _iHttpGet;
        public CalendarsControllers(IHttpGet<dynamic> iHttpGet)
        {
            _iHttpGet = iHttpGet;
        }
    }
}
