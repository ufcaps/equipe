using Backend.Core.Application.UseCases.User.CreateUser;
using Backend.Core.Application.UseCases.User.DeleteUser;
using Backend.Core.Application.UseCases.User.GetUserById;
using Backend.Core.Application.UseCases.User.UpdateUser;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Presentation.Api.Controllers;

[ApiController]
[Route("user")]
public class UserController(IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator = mediator;

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateUserRequest request, CancellationToken cancellationToken)
    {
        var user = await _mediator.Send(request, cancellationToken);

        return Created($"/user/{user.Id}", new
        {
            success = true,
            message = "User created successfully",
            data = user
        });
    }

    [Authorize]
    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateUserRequest request, CancellationToken cancellationToken)
    {
        request.Id = id;
        var user = await _mediator.Send(request, cancellationToken);

        return Ok(new
        {
            success = true,
            message = "User updated successfully",
            data = user
        });
    }

    [Authorize]
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
    {
        await _mediator.Send(new DeleteUserRequest(id), cancellationToken);

        return Ok(new
        {
            success = true,
            message = "User deleted successfully"
        });
    }

    [Authorize]
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id, CancellationToken cancellationToken)
    {
        var user = await _mediator.Send(new GetUserByIdRequest(id), cancellationToken);

        return Ok(new
        {
            success = true,
            message = "User retrieved successfully",
            data = user
        });
    }
}
