using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using SiggAgroCoop.IntegrationTests.Auth;

namespace SiggAgroCoop.IntegrationTests.TestHost;

public class CustomWebApplicationFactory
    : WebApplicationFactory<Program>
{
    protected override IHost CreateHost(IHostBuilder builder)
    {
        builder.UseEnvironment("Testing");

        builder.ConfigureServices(services =>
        {
            // Remove autenticação real (JWT)
            services.RemoveAll<AuthenticationSchemeOptions>();

            // Adiciona autenticação fake para testes
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = TestAuthHandler.AuthenticationSchemeName;
                options.DefaultChallengeScheme = TestAuthHandler.AuthenticationSchemeName;
            })
            .AddScheme<AuthenticationSchemeOptions, TestAuthHandler>(
                TestAuthHandler.AuthenticationSchemeName,
                options => { }
            );
        });

        return base.CreateHost(builder);
    }
}
