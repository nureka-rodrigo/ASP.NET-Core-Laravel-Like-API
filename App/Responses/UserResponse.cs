using AspNetCoreLaravelAPI.App.Models;

namespace AspNetCoreLaravelAPI.App.Responses;

public record UserResponse(
    string? FirstName,
    string? LastName,
    string? Email,
    DateOnly? DateOfBirth,
    string? Gender,
    string? PhoneNumber,
    string? Address
)
{
    public static UserResponse FromDomain(User user)
    {
        return new UserResponse
        (
            user.FirstName,
            user.LastName,
            user.Email,
            user.DateOfBirth,
            user.Gender,
            user.PhoneNumber,
            user.Address
        );
    }
}