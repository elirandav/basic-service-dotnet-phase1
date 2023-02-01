using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Users.API;
using Users.Tests.Helpers.Helpers;
using Xunit.Abstractions;

namespace Users.Tests.Helpers
{
    static class TestClientApplicationFactory
    {
        public static HttpClient CreateClient<TStartup>(this WebApplicationFactory<TStartup> factory, ITestOutputHelper output, HttpMessageHandler? handler) where TStartup : class
        {
            var newFactory = factory.WithWebHostBuilder(builder =>
            {
                if (handler != null)
                {
                    var clientFactory = new MockClientFactory(handler);
                    builder.ConfigureServices(services =>
                    {
                        services.AddSingleton<IHttpClientWithHandlerFactory>(clientFactory);
                    });
                }
                builder.ConfigureLogging(logging =>
                {
                    var useScopes = logging.UsesScopes();
                    logging.ClearProviders();
                    logging.Services.AddSingleton<ILoggerProvider>(r => new XunitLoggerProvider(output, useScopes));
                });
            });

            var httpClient = newFactory.CreateClient();
            return httpClient;
        }
    }
}
