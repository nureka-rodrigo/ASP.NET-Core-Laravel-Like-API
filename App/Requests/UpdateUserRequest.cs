using System.ComponentModel.DataAnnotations;

using AspNetCoreLaravelAPI.App.Models;

namespace AspNetCoreLaravelAPI.App.Requests;

public record UpdateUserRequest(
    [StringLength(50, MinimumLength = 2)]
    string? FirstName,

    [StringLength(50, MinimumLength = 2)]
    string? LastName,

    [EmailAddress]
    string? Email,

    DateOnly? DateOfBirth,

    [StringLength(6, MinimumLength = 4)]
    string? Gender,

    [Phone]
    string? PhoneNumber,

    [StringLength(100, MinimumLength = 10)]
    string? Address
)
{
    public User ToDomain()
    {
        return new User
        {
            FirstName = FirstName,
            LastName = LastName,
            Email = Email,
            PhoneNumber = PhoneNumber,
            Address = Address,
            DateOfBirth = DateOfBirth!.Value,
            Gender = Gender,
        };
    }
}