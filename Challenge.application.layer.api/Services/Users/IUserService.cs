using challenge.domain.layer.api.Dtos;

namespace challenge.application.layer.api.Services.Users
{
    public interface IUserService
    {
        Task<IEnumerable<UserDto>> GetUsers();
    }
}
