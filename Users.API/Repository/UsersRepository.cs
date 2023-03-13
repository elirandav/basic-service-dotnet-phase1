using Users.API;

public class UsersRepository : IUsersRepository
{
    HttpClient _httpClient;
    public UsersRepository(IHttpClientWithHandlerFactory clientFactory)
    {
        _httpClient = clientFactory.Create();
    }
    public async Task<UserRecord[]> GetUsers()
    {
        var response = await _httpClient.GetAsync("http://external-service/records");
        return await response.Content.ReadFromJsonAsync<UserRecord[]>();
    }
}