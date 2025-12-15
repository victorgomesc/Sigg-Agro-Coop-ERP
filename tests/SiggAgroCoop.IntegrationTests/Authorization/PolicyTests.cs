using System.Net;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using SiggAgroCoop.Application.DTOs.Auth;
using SiggAgroCoop.IntegrationTests.TestHost;
using Xunit;

namespace SiggAgroCoop.IntegrationTests.Authorization;

public class PolicyTests(CustomWebApplicationFactory factory) : IClassFixture<CustomWebApplicationFactory>
{
    private readonly HttpClient _client = factory.CreateClient();

    private async Task<string> RegisterAndGetToken(string email, string role)
    {
        var resp = await _client.PostAsJsonAsync("/api/auth/register", new RegisterUserDto
        {
            FullName = $"User {role}",
            Email = email,
            Password = "123456",
            Role = role
        });

        resp.EnsureSuccessStatusCode();

        var body = await resp.Content.ReadFromJsonAsync<AuthResponseDto>();
        return body!.Token;
    }

    [Fact]
    public async Task AdminOnly_Should_Return_200_For_Admin()
    {
        var token = await RegisterAndGetToken("admin@local.com", "Admin");

        _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

        var resp = await _client.PostAsync("/api/user/admin-action", null);

        Assert.Equal(HttpStatusCode.OK, resp.StatusCode);
    }

    [Fact]
    public async Task AdminOnly_Should_Return_403_For_Employee()
    {
        var token = await RegisterAndGetToken("emp@local.com", "Employee");

        _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

        var resp = await _client.PostAsync("/api/user/admin-action", null);

        Assert.Equal(HttpStatusCode.Forbidden, resp.StatusCode);
    }

    [Fact]
    public async Task EmployeeOnly_Should_Return_200_For_Employee()
    {
        var token = await RegisterAndGetToken("emp2@local.com", "Employee");

        _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

        var resp = await _client.PostAsync("/api/user/employee-action", null);

        Assert.Equal(HttpStatusCode.OK, resp.StatusCode);
    }
}
