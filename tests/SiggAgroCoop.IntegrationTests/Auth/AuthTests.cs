using System.Net;
using System.Net.Http.Json;
using SiggAgroCoop.Application.DTOs.Auth;
using SiggAgroCoop.IntegrationTests.TestHost;
using Xunit;

namespace SiggAgroCoop.IntegrationTests.Auth;

public class AuthTests : IClassFixture<CustomWebApplicationFactory>
{
    private readonly HttpClient _client;

    public AuthTests(CustomWebApplicationFactory factory)
    {
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task Register_Should_Return_Token_And_ExpiresAt()
    {
        var dto = new RegisterUserDto
        {
            FullName = "Victor Test",
            Email = "victor_test@local.com",
            Password = "123456",
            Role = "Employee"
        };

        var resp = await _client.PostAsJsonAsync("/api/auth/register", dto);

        resp.EnsureSuccessStatusCode();

        var body = await resp.Content.ReadFromJsonAsync<AuthResponseDto>();
        Assert.NotNull(body);
        Assert.False(string.IsNullOrWhiteSpace(body!.Token));
        Assert.Equal("Employee", body.Role);
        Assert.NotEqual(default, body.ExpiresAt);
    }

    [Fact]
    public async Task Login_Should_Return_Token_When_Credentials_Are_Valid()
    {
        // Register first
        await _client.PostAsJsonAsync("/api/auth/register", new RegisterUserDto
        {
            FullName = "User Login",
            Email = "login@local.com",
            Password = "123456",
            Role = "Employee"
        });

        // Login
        var resp = await _client.PostAsJsonAsync("/api/auth/login", new LoginDto
        {
            Email = "login@local.com",
            Password = "123456"
        });

        resp.EnsureSuccessStatusCode();

        var body = await resp.Content.ReadFromJsonAsync<AuthResponseDto>();
        Assert.NotNull(body);
        Assert.False(string.IsNullOrWhiteSpace(body!.Token));
    }
}
