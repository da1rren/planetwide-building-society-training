
using Microsoft.AspNetCore.Mvc.Testing;

namespace Planetwide.Basic.Tests.People;

public class MutationQueryTests : IClassFixture<WebServerFixture>
{
    internal WebApplicationFactory<Program> Server { get; init; }

    public HttpClient Client { get; init; }

    public MutationQueryTests(WebServerFixture fixture)
    {
        Server = fixture.Server;
        Client = fixture.Client;
    }

    [Fact]
    public async Task Ensure_Add_Person_Adds_A_Person()
    {
        // The web app factory should be extracted to a fixture 

        var addRequest = await Client.PostAsJsonAsync("/graphql", new
        {
            query = @"
mutation addPerson{
  addPerson(name: ""Darren"") {
    id
    name
  }
}"
        });

        addRequest.EnsureSuccessStatusCode();

        var listRequest = await Client.PostAsJsonAsync("/graphql", new
        {
            query = @"{ people{ id name } }"
        });


        var response = await listRequest.Content.ReadAsStringAsync();
        listRequest.EnsureSuccessStatusCode();
        Snapshot.Match(response);
    }
}

