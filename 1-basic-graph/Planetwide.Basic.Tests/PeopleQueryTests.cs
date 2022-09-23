using System.Text.Json;
using System.Text.Json.Serialization;
using HotChocolate.Execution;
using Microsoft.AspNetCore.Mvc.Testing;

namespace Planetwide.Basic.Tests;

public class PeopleQueryTests
{
    public PeopleQueryTests()
    {

    }

    [Fact]
    public async Task Ensure_Get_Person_Returns_Person()
    {
        // The web app factory should be extracted to a fixture 
        var application = new WebApplicationFactory<Program>()
            .WithWebHostBuilder(builder =>
            {
                // ... Configure test services
            });

        var client = application.CreateClient();

        var request = await client.PostAsJsonAsync("/graphql", new
        {
            query = @"
                { person { name }}
            "
        });

        var response = await request.Content.ReadAsStringAsync();
        request.EnsureSuccessStatusCode();
        Snapshot.Match(response);
    }
}

