using Backend.Core.Application.UseCases.Task.CreateTask;
using Backend.Core.Application.UseCases.Task.DeleteTask;
using Backend.Core.Application.UseCases.Task.GetTaskById;
using Backend.Core.Application.UseCases.Task.GetTasksByUserId;
using Backend.Core.Application.UseCases.Task.UpdateTask;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Presentation.Api.Controllers;

[ApiController]
[Route("task")]
public class TaskController(IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator = mediator;

    [Authorize]
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateTaskRequest request, CancellationToken cancellationToken)
    {
        var task = await _mediator.Send(request, cancellationToken);

        return Created($"/task/{task.Id}", new
        {
            success = true,
            message = "Task created successfully",
            data = task
        });
    }

    [Authorize]
    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateTaskRequest request, CancellationToken cancellationToken)
    {
        request.Id = id;
        var task = await _mediator.Send(request, cancellationToken);

        return Ok(new
        {
            success = true,
            message = "Task updated successfully",
            data = task
        });
    }

    [Authorize]
    [HttpDelete]
    [Route("{id:int}")]
    public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
    {
        await _mediator.Send(new DeleteTaskRequest(id), cancellationToken);

        return Ok(new
        {
            success = true,
            message = "Task deleted successfully"
        });
    }

    [Authorize]
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id, CancellationToken cancellationToken)
    {
        var task = await _mediator.Send(new GetTaskByIdRequest(id), cancellationToken);

        return Ok(new
        {
            success = true,
            message = "Task retrieved successfully",
            data = task
        });
    }

    [Authorize]
    [HttpGet("user/{userId:int}")]
    public async Task<IActionResult> GetByUserId(int userId, CancellationToken cancellationToken)
    {
        var task = await _mediator.Send(new GetTasksByUserIdRequest(userId), cancellationToken);

        return Ok(new
        {
            success = true,
            message = "Tasks retrieved successfully",
            data = task
        });
    }
}
