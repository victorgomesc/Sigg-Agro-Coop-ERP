using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Security.Claims;
using System.Text.Encodings.Web;

namespace SiggAgroCoop.IntegrationTests.Auth;

public class TestAuthHandler
    : AuthenticationHandler<AuthenticationSchemeOptions>
{
    public const string AuthenticationSchemeName = "TestScheme";
    #pragma warning disable CS0618
    public TestAuthHandler(
        IOptionsMonitor<AuthenticationSchemeOptions> options,
        ILoggerFactory logger,
        UrlEncoder encoder,
        ISystemClock clock // ⚠️ ainda obrigatório
    ) : base(options, logger, encoder, clock)
    {
    }
    #pragma warning restore CS0618

    protected override Task<AuthenticateResult> HandleAuthenticateAsync()
    {
        var role = Context.Request.Headers["X-Test-Role"].ToString();

        if (string.IsNullOrWhiteSpace(role))
        {
            return Task.FromResult(
                AuthenticateResult.Fail("No test role provided"));
        }

        var claims = new[]
        {
            new Claim(ClaimTypes.NameIdentifier, "test-user"),
            new Claim(ClaimTypes.Email, "test@test.com"),
            new Claim(ClaimTypes.Role, role)
        };

        var identity = new ClaimsIdentity(
            claims, AuthenticationSchemeName);

        var principal = new ClaimsPrincipal(identity);
        var ticket = new AuthenticationTicket(
            principal, AuthenticationSchemeName);

        return Task.FromResult(
            AuthenticateResult.Success(ticket));
    }
}
