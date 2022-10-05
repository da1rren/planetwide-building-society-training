using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Planetwide.Basic;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddGraphQLServer()
    .AddQueryType<QueryRoot>()
    .AddMutationType<MutationRoot>()
    .AddSubscriptionType<SubscriptionRoot>()
    .AddType<FastCar>()
    .AddType<EfficientCar>()
    .AddInMemorySubscriptions();

var app = builder.Build();

app.UseRouting();

app.UseWebSockets();

app.UseEndpoints(endpoints =>
{
    endpoints.MapGraphQL();
});

app.Run();
