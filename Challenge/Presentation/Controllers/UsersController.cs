using Challenge.bootstrapper.layer.api.Application;
using Challenge.bootstrapper.layer.api.Dtos;
using Challenge.bootstrapper.layer.api.Infrastructure.HttpRequest.Get;
using Challenge.bootstrapper.layer.api.Infrastructure.HttpRequest.Post;
using Microsoft.AspNetCore.Mvc;

namespace Challenge.bootstrapper.layer.api.Controllers
{
    public class UsersController : BaseController
    {
        private readonly IHttpPost<dynamic> _post;
        private readonly IHttpGet<dynamic> _get;
        private readonly IRequestToken _requestToken;
       
        public UsersController(IHttpPost<dynamic> post, IHttpGet<dynamic> get, IRequestToken requestToken)
        {
            _post = post;
            _get = get;
            _requestToken = requestToken;
        }

        [HttpGet("GetUsers")]
        public async Task<ActionResult<UserDto>> GetUsers()
        {
            var token = await _requestToken.Get();

            return Ok();
        }
    }
}
