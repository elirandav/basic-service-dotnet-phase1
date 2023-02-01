using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Moq;
using Users.API;
using Users.Tests.Helpers.Helpers;
using Xunit.Abstractions;

namespace Users.Tests.Helpers
{
    static class TestClientApplicationFactory
    {
        public static HttpClient CreateClient<TStartup>(this WebApplicationFactory<TStartup> factory, ITestOutputHelper output, Mock<HttpMessageHandler> mockedMessageHandler) where TStartup : class
        {
            var newFactory = factory.WithWebHostBuilder(builder =>
            {
                var clientFactory = new MockClientFactory(mockedMessageHandler.Object);
                builder.ConfigureServices(services =>
                {
                    services.AddSingleton<IHttpClientWithHandlerFactory>(clientFactory);
                });

                AddServerOutputToConsole(output, builder);
            });

            var httpClient = newFactory.CreateClient();
            return httpClient;
        }

        public static HttpClient CreateClient<TStartup>(this WebApplicationFactory<TStartup> factory, ITestOutputHelper output) where TStartup : class
        {
            var newFactory = factory.WithWebHostBuilder(builder =>
            {
                AddServerOutputToConsole(output, builder);
            });

            var httpClient = newFactory.CreateClient();
            return httpClient;
        }

        private static void AddServerOutputToConsole(ITestOutputHelper output, IWebHostBuilder builder)
        {
            builder.ConfigureLogging(logging =>
            {
                var useScopes = logging.UsesScopes();
                logging.ClearProviders();
                logging.Services.AddSingleton<ILoggerProvider>(r => new XunitLoggerProvider(output, useScopes));
            });
        }
    }
}

