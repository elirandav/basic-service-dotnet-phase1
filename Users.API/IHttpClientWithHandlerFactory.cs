namespace Users.API
{
    public interface IHttpClientWithHandlerFactory
    {
        HttpClient Create();
    }
}
