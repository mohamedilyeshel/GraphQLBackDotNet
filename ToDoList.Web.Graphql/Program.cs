using HotChocolate.Types.Pagination;
using Microsoft.EntityFrameworkCore;
using ToDoList.Common.CustomExceptions.ErrorFilter;
using ToDoList.DataAccess;
using ToDoList.DataAccess.Repositories;
using ToDoList.DataAccess.Schema.Queries;
using ToDoList.Web.Graphql.DataLoaders;
using ToDoList.Web.Graphql.Schema.Mutations;
using ToDoList.Web.Graphql.Schema.Subscriptions;
using ToDoList.Web.Graphql.Schema.Subscriptions.UserSubscriptions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ToDoListContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("DbConString")).UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
, ServiceLifetime.Transient);
builder.Services.AddErrorFilter<AppErrorFilter>();
builder.Services.AddTransient(typeof(UserRepository));
builder.Services.AddTransient(typeof(ToDoRepository));
builder.Services
    .AddGraphQLServer()
    .AddInMemorySubscriptions()
    .AddDefaultTransactionScopeHandler()
    .AddTypeExtension<UserMutation>()
    .AddTypeExtension<ToDoMutation>()
    .AddTypeExtension<UserSubscription>()
    .AddQueryType<Query>()
    .AddMutationType<Mutation>()
    .AddSubscriptionType<Subscription>()
    .SetPagingOptions(new PagingOptions
    {
        DefaultPageSize = 25,
        IncludeTotalCount = true
    })
    .AddFiltering()
    .AddProjections()
    .AddDataLoader<UserBatchDataLoader>();


var app = builder.Build();

app.UseWebSockets();

app.MapGraphQL("/todolist");

app.Run();
