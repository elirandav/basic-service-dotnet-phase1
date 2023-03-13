using Users.API.Controllers;

namespace Users.API.Service
{
    public interface IUsersService
    {
        Task<UserResponseDto[]> GetUsers();
    }
}