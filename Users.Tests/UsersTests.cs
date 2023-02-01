using Microsoft.AspNetCore.Mvc.Testing;
using Xunit.Abstractions;

namespace Users.Tests;

public class UsersTests
    : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly WebApplicationFactory<Program> _factory;
    private readonly ITestOutputHelper _output;

    public UsersTests(WebApplicationFactory<Program> factory, ITestOutputHelper output)
    {
        _factory = factory;
        _output = output;
    }

}