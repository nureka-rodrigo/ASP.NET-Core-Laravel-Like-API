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

    [HttpGet("{userId:guid}")]
    public IActionResult Get(Guid userId)
    {
        var user = _usersService.Get(userId);

        return user is null
            ? NotFound(
                new
                {
                    message = "User not found"
                }
            )
            : Ok(
                new
                {
                    message = "User found",
                    user = UserResponse.FromDomain(user)
                }
            );
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var users = _usersService.GetAll();
        var userResponses = users.Select(UserResponse.FromDomain).ToList();

        return Ok(
            new
            {
                message = "Users found",
                users = userResponses
            }
        );
    }

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
                message = "User created.",
                user = UserResponse.FromDomain(user)
            }
        );
    }

    [HttpPut("{userId:guid}")]
    public IActionResult Update(Guid userId, UpdateUserRequest request)
    {
        var user = request.ToDomain();
        var status = _usersService.Update(user, userId);

        return !status
            ? NotFound(
                new
                {
                    message = "User not found"
                }
            )
            : Ok(
            new
            {
                message = "User Updated",
                user = UserResponse.FromDomain(user)
            }
        );
    }

    [HttpDelete("{userId:guid}")]
    public IActionResult Delete(Guid userId)
    {
        var status = _usersService.Delete(userId);

        return !status
            ? NotFound(
                new
                {
                    message = "User not found"
                }
            )
            : Ok(
            new
            {
                message = "User Deleted"
            }
        );
    }
}