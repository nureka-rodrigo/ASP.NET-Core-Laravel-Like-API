using AspNetCoreLaravelAPI.App.Models;
using AspNetCoreLaravelAPI.Database.Contexts;

namespace AspNetCoreLaravelAPI.App.Services;

public class UsersService(ApplicationDbContext context)
{
    private readonly ApplicationDbContext _context = context;

    public User? Get(Guid userId)
    {
        return _context.Users.Find(userId);
    }

    public List<User> GetAll()
    {
        return [.. _context.Users];
    }

    public void Create(User user)
    {
        _context.Users.Add(user);
        _context.SaveChanges();
    }

    public bool Update(User user, Guid userId)
    {
        var existingUser = _context.Users.Find(userId);

        if (existingUser == null)
        {
            return false;
        }

        existingUser.FirstName = user.FirstName;
        existingUser.LastName = user.LastName;
        existingUser.Email = user.Email;
        existingUser.PhoneNumber = user.PhoneNumber;
        existingUser.Address = user.Address;
        existingUser.DateOfBirth = user.DateOfBirth;
        existingUser.Gender = user.Gender;
        existingUser.Password = user.Password;

        _context.SaveChanges();
        return true;
    }

    public bool Delete(Guid userId)
    {
        var existingUser = _context.Users.Find(userId);

        if (existingUser == null)
        {
            return false;
        }

        _context.Users.Remove(existingUser);
        _context.SaveChanges();

        return true;
    }
}