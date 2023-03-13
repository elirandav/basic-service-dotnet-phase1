using Users.API;

internal class HttpClientWithHandlerFactory : IHttpClientWithHandlerFactory
{
    public HttpClient Create()
    {
        return new HttpClient();
    }
}