using Microsoft.AspNetCore.Mvc.Testing;

namespace Planetwide.Basic.Tests.Fixtures;

public class WebServerFixture : IDisposable
{
    internal WebApplicationFactory<Program> Server { get; init; }

    public HttpClient Client { get; init; }

    public WebServerFixture()
    {
        Server = new WebApplicationFactory<Program>()
            .WithWebHostBuilder(builder =>
            {
                // ... Configure test services
            });

        Client = Server.CreateClient();
    }

    public void Dispose()
    {
        Server.Dispose();
    }
}