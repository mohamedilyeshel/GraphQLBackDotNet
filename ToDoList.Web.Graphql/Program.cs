using HotChocolate;
using HotChocolate.AspNetCore.Serialization;
using HotChocolate.Types.Pagination;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using ToDoList.Common;
using ToDoList.Common.CustomExceptions;
using ToDoList.Common.CustomExceptions.ErrorFilter;
using ToDoList.DataAccess;
using ToDoList.DataAccess.Repositories;
using ToDoList.DataAccess.Schema.Queries;
using ToDoList.Web.Graphql.AuthModel;
using ToDoList.Web.Graphql.DataLoaders;
using ToDoList.Web.Graphql.Schema.Mutations;
using ToDoList.Web.Graphql.Schema.Subscriptions;
using ToDoList.Web.Graphql.Schema.Subscriptions.UserSubscriptions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ToDoListContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("DbConString")).UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
, ServiceLifetime.Transient);

builder.Services.AddTransient(typeof(UserRepository));
builder.Services.AddTransient(typeof(ToDoRepository));
builder.Services.AddCors(
    options =>
    {
        options.AddPolicy("AllowAnyOrigin", builder =>
        {
            builder.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
        });
    }
    );
builder.Services.Configure<TokenSettings>(builder.Configuration.GetSection("TokenSettings"));
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidIssuer = builder.Configuration.GetSection("TokenSettings").GetValue<string>("Issuer"),
                ValidateIssuer = true,
                ValidAudience = builder.Configuration.GetSection("TokenSettings").GetValue<string>("Audience"),
                ValidateAudience = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration.GetSection("TokenSettings").GetValue<string>("Key"))),
                ValidateIssuerSigningKey = true
            };
        }
    );
builder.Services.AddAuthorization();
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
    .AddDataLoader<UserBatchDataLoader>()
    .AddAuthorization();

var app = builder.Build();

app.UseAuthentication();

app.UseAuthorization();

app.UseWebSockets();

app.UseCors("AllowAnyOrigin");

app.MapGraphQL("/todolist");

app.Run();
