using AspNetCoreLaravelAPI.App.Models;

using Microsoft.EntityFrameworkCore;

namespace AspNetCoreLaravelAPI.Database.Contexts;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    public required DbSet<User> Users { get; set; }
}