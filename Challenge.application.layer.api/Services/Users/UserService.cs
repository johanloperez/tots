using challenge.application.layer.Services.Users;
using challenge.domain.layer.Contracts;
using challenge.domain.layer.Dtos;

namespace challenge.application.layer.Services.users
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
