using Backend.Core.Application.UseCases.Auth.Login;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Presentation.Api.Controllers;

[ApiController]
[Route("auth")]
public class AuthController(IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator = mediator;

    [HttpPost]
    public async Task<IActionResult> Login([FromBody] LoginRequest request, CancellationToken cancellationToken)
    {
        var data = await _mediator.Send(request, cancellationToken);

        return Ok(new
        {
            success = true,
            message = "Login successful",
            data
        });
    }
}
