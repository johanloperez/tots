using challenge.domain.layer.Dtos;

namespace challenge.application.layer.Services.Users
{
    public interface IUserService
    {
        Task<IEnumerable<UserDto>> GetUsers();
    }
}
