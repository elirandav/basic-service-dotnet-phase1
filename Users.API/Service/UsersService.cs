using Users.API.Controllers;
using Users.API.Service;

public class UsersService : IUsersService
{
    private readonly IUsersRepository _usersRepository;

    public UsersService(IUsersRepository usersRepository)
    {
        _usersRepository = usersRepository;
    }

    public async Task<UserResponseDto[]> GetUsers()
    {
        UserRecord[] records = await _usersRepository.GetUsers();
        return records.Select(record => new UserResponseDto
        {
            Id = record.Id,
            Name = record.FirstName
        }).ToArray();       
    }
}