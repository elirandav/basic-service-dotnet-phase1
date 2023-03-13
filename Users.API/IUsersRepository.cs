public interface IUsersRepository
{
    Task<UserRecord[]> GetUsers();
}