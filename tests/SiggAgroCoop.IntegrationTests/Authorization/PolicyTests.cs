using System.Net;
using Xunit;
using SiggAgroCoop.IntegrationTests.TestHost;

namespace SiggAgroCoop.IntegrationTests.Authorization;

public class PolicyTests : IClassFixture<CustomWebApplicationFactory>
{
    private readonly HttpClient _client;

    public PolicyTests(CustomWebApplicationFactory factory)
    {
        _client = factory.CreateClient();
    }

    private void SetRole(string role)
    {
        _client.DefaultRequestHeaders.Remove("X-Test-Role");
        _client.DefaultRequestHeaders.Add("X-Test-Role", role);
    }

    [Fact]
    public async Task AdminOnly_Should_Return_200_For_Admin()
    {
        SetRole("Admin");

        var response = await _client.PostAsync("/api/user/admin-action", null);

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }

    [Fact]
    public async Task AdminOnly_Should_Return_403_For_Employee()
    {
        SetRole("Employee");

        var response = await _client.PostAsync("/api/user/admin-action", null);

        Assert.Equal(HttpStatusCode.Forbidden, response.StatusCode);
    }

    [Fact]
    public async Task EmployeeOnly_Should_Return_200_For_Employee()
    {
        SetRole("Employee");

        var response = await _client.PostAsync("/api/user/employee-action", null);

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }
}
