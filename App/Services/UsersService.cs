using AspNetCoreLaravelAPI.App.Models;

namespace AspNetCoreLaravelAPI.App.Services;


public class UsersService
{
    public User Get(Guid userId)
    {
        // Get user from database
        return new User();
    }

    public void Create(User user)
    {
        // Save user to database
    }

    public void Update(User user, Guid userId)
    {
        // Update user in database
    }

    public void Delete(Guid userId)
    {
        // Delete user from database
    }
}