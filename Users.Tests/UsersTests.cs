using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Moq;
using System.Net.Http.Json;
using Users.API.Controllers;
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

    [Fact]
    public async Task GetUsers_FirstNameOnly()
    {
        // arrange
        Mock<HttpMessageHandler> mockedMessageHandler = HandlerMessage.Intercept("http://external-service/records", RecordsMockFirstNameOnly());
        var client = _factory.CreateClient(_output, mockedMessageHandler);

        // act
        var response = await client.GetAsync("/users");


        // assert
        response.EnsureSuccessStatusCode();
        var actualUsers = await response.Content.ReadFromJsonAsync<UserResponseDto[]>();
        actualUsers.Should().BeEquivalentTo(GetExpectedUsersFirstNameOnly());
    }

    private UserRecord[] RecordsMockFirstNameOnly()
    {
        return new UserRecord[]
        {
            new UserRecord { Id = 1, FirstName = "Zehava"},
            new UserRecord {Id = 2, FirstName = "Billie"}
        };
    }


    private UserResponseDto[] GetExpectedUsersFirstNameOnly()
    {
        return new UserResponseDto[]
        {
            new UserResponseDto {Id = 1, Name = "Zehava"},
            new UserResponseDto {Id = 2, Name = "Billie"}
        };
    }
}