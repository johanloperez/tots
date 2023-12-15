using challenge.application.layer.api.Services.Users;
using challenge.domain.layer.api.Contracts;
using challenge.domain.layer.api.Dtos;

namespace challenge.application.layer.api.Services.users
{
    public class UserService : IUserService
    {
        private readonly IMicrosoftGraphApiService _mgApiService;

        public UserService(IMicrosoftGraphApiService mgApiService) 
        {
            _mgApiService = mgApiService;
        }

        public async Task<IEnumerable<UserDto>> GetUsers()
        {
            return await _mgApiService.GetAllUsers();
        }
    }
}
