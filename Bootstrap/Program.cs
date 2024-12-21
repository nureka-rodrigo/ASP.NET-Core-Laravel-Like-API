using AspNetCoreLaravelAPI.Database.Contexts;
using AspNetCoreLaravelAPI.App.Services;
using AspNetCoreLaravelAPI.Routes;

using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddJsonFile("Config/appsettings.json", optional: false, reloadOnChange: true);

builder.Services.AddScoped<UsersService>();
builder.Services.AddControllers();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

var app = builder.Build();

APIRoutes.RegisterRoutes(app);

app.Run();