using AspNetCoreLaravelAPI.Routes;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllers();

var app = builder.Build();

// Use centralized route configuration
APIRoutes.RegisterRoutes(app);

app.Run();