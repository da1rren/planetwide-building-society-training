
using Microsoft.AspNetCore.Mvc.Testing;

namespace Planetwide.Basic.Tests.People;

public class PeopleQueryTests : IClassFixture<WebServerFixture>
{
    internal WebApplicationFactory<Program> Server { get; init; }

    public HttpClient Client { get; init; }

    public PeopleQueryTests(WebServerFixture fixture)
    {
        Server = fixture.Server;
        Client = fixture.Client;
    }

    [Fact]
    public async Task Ensure_Get_Person_Returns_Person()
    {
        var request = await Client.PostAsJsonAsync("/graphql", new
        {
            query = @"{ people{ name } }"
        });

        var response = await request.Content.ReadAsStringAsync();
        request.EnsureSuccessStatusCode();
        Snapshot.Match(response);
    }

    [Fact]
    public async Task Ensure_Get_Cars_Returns_Cars()
    {
        var request = await Client.PostAsJsonAsync("/graphql", new
        {
            query = @"
{
  cars{
    model

    ... on EfficientCar {
      maxRange
    }

    ... on FastCar {
      maxKph
    }
  }
}           
            "
        });

        var response = await request.Content.ReadAsStringAsync();
        request.EnsureSuccessStatusCode();
        Snapshot.Match(response);
    }
}

