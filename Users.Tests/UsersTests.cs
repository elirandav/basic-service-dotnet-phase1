using Microsoft.AspNetCore.Mvc.Testing;
using Moq;
using Users.Tests.Helpers;
using Xunit.Abstractions;

namespace Users.Tests;

public class UsersTests
    : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly WebApplicationFactory<Program> _factory;
    private readonly ITestOutputHelper _output;

/*    Utils example usage:  *    
 *    Mock<HttpMessageHandler> mockedMessageHandler = HandlerMessage.Intercept("url", response);
    var client = _factory.CreateClient(_output, mockedMessageHandler);*/

    public UsersTests(WebApplicationFactory<Program> factory, ITestOutputHelper output)
    {
        _factory = factory;
        _output = output;
    }

}