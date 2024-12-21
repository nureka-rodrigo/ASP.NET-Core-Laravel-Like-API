using AspNetCoreLaravelAPI.App.Services;
using AspNetCoreLaravelAPI.Routes;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddScoped<UsersService>();
    builder.Services.AddControllers();
}

var app = builder.Build();
{
    APIRoutes.RegisterRoutes(app);
}

app.Run();