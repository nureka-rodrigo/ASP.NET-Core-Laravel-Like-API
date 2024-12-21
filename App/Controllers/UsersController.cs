using AspNetCoreLaravelAPI.App.Requests;
using AspNetCoreLaravelAPI.App.Responses;
using AspNetCoreLaravelAPI.App.Services;

using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreLaravelAPI.App.Controllers;

[ApiController]
[Route("api/users")]
public class CreateUserController(UsersService usersService) : ControllerBase
{
    private readonly UsersService _usersService = usersService;

    [HttpPost]
    public IActionResult CreateUser(CreateUserRequest request)
    {
        if (!request.IsPasswordMatch())
        {
            return BadRequest(
                new
                {
                    message = "Password and Confirm Password do not match"
                }
            );
        }

        var user = request.ToDomain();

        _usersService.Create(user);

        return CreatedAtAction(
            actionName: "CreateUser",
            routeValues: new
            {
                userId = user.Id
            },
            value: new
            {
                message = "User created successfully.",
                user = UserResponse.FromDomain(user)
            }
        );
    }
}