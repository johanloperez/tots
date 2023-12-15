using challenge.application.layer.api.Services.Users;
using challenge.domain.layer.api.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace challenge.presentation.layer.api.Controllers
{
    public class UsersController : BaseController
    {
        private readonly IUserService _userService;

        public UsersController(IUserService  userService)
        {
            _userService = userService;
        }

        [HttpGet("GetUsers")]
        public async Task<ActionResult<UserDto>> GetUsers()
        {
            return Ok(await _userService.GetUsers());
        }
    }
}
