using challenge.application.layer.Services.Users;
using challenge.domain.layer.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace challenge.presentation.layer.Controllers
{
    public class UsersController : BaseController
    {
        private readonly IUserService _userService;

        public UsersController(IUserService  userService)
        {
            _userService = userService;
        }

        //[Authorize(AuthenticationSchemes = "Bearer")]
        [HttpGet("GetUsers")]
        public async Task<ActionResult<UserDto>> GetUsers()
        {
            return Ok(await _userService.GetUsers());
        }
    }
}
