using Users.API;

namespace Users.Tests.Helpers
{
    internal class MockClientFactory : IHttpClientWithHandlerFactory
    {
        private readonly HttpMessageHandler handler;

        public MockClientFactory(HttpMessageHandler handler)
        {
            this.handler = handler;
        }
        public HttpClient Create()
        {
            return new HttpClient(handler);
        }
    }
}