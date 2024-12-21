using System.ComponentModel.DataAnnotations;

using AspNetCoreLaravelAPI.App.Models;

namespace AspNetCoreLaravelAPI.App.Requests;

public record CreateUserRequest(
    [Required]
    [StringLength(50, MinimumLength = 2)]
    string FirstName,

    [Required]
    [StringLength(50, MinimumLength = 2)]
    string LastName,

    [Required]
    [EmailAddress]
    string Email,

    [Required]
    [Phone]
    string PhoneNumber,

    [Required]
    [StringLength(100, MinimumLength = 10)]
    string Address,

    [Required]
    DateOnly? DateOfBirth,

    [Required]
    [RegularExpression("^(Male|Female)$", ErrorMessage = "Gender must be either 'Male' or 'Female'")]
    string Gender,

    [Required]
    [RegularExpression("^(?=.*[0-9])(?=.*[a-z])(?=.*[A-Z])(?=.*\\W)(?!.* ).{8,100}$", ErrorMessage = "Password must be at least 8 characters long, contain at least one uppercase letter, one lowercase letter, one digit, and one special character.")]
    string Password,

    [Required]
    [StringLength(100, MinimumLength = 8)]
    string ConfirmPassword
)
{
    public bool IsPasswordMatch()
    {
        return Password == ConfirmPassword;
    }

    public User ToDomain()
    {
        return new User
        {
            Id = Guid.NewGuid(),
            FirstName = FirstName,
            LastName = LastName,
            Email = Email,
            PhoneNumber = PhoneNumber,
            Address = Address,
            DateOfBirth = DateOfBirth!.Value,
            Gender = Gender,
            Password = Password
        };
    }
}