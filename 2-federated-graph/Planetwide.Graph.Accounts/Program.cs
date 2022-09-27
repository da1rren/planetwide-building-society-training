using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Planetwide.Graph.Accounts;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddGraphQLServer()
    .AddQueryType<Query>();

var app = builder.Build();

app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapGraphQL();
});

app.Run();
