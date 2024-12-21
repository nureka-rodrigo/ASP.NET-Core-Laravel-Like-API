using AspNetCoreLaravelAPI.Database.Contexts;
using AspNetCoreLaravelAPI.App.Services;
using AspNetCoreLaravelAPI.Routes;

using Microsoft.EntityFrameworkCore;
using DotNetEnv;

var builder = WebApplication.CreateBuilder(args);

Env.Load();

var dbHost = Environment.GetEnvironmentVariable("DB_HOST");
var dbPort = Environment.GetEnvironmentVariable("DB_PORT");
var dbName = Environment.GetEnvironmentVariable("DB_NAME");
var dbUser = Environment.GetEnvironmentVariable("DB_USER");
var dbPassword = Environment.GetEnvironmentVariable("DB_PASSWORD");
var connectionString = $"server={dbHost};port={dbPort};database={dbName};user={dbUser};password={dbPassword}";

builder.Configuration.AddEnvironmentVariables();
builder.Configuration.AddJsonFile("Config/appsettings.json", optional: false, reloadOnChange: true);
builder.Services.AddScoped<UsersService>();
builder.Services.AddControllers();
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

var app = builder.Build();

APIRoutes.RegisterRoutes(app);

app.Run();