using Microsoft.AspNetCore.Mvc;
using TodoList.Application.Requests;

namespace TodoList.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TodoController : ControllerBase
{
    private readonly ITodoService _service;

    public TodoController(ITodoService service) => _service = service;

    [HttpGet]
    public async Task<IActionResult> GetAll() => Ok(await _service.GetAllAsync());

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var todo = await _service.GetByIdAsync(id);
        return todo is null ? NotFound() : Ok(todo);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateTodoRequest request)
    {
        var todo = await _service.CreateAsync(request);
        return CreatedAtAction(nameof(GetById), new { id = todo.Id }, todo);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, UpdateTodoRequest request)
    {
        if (id != request.Id) return BadRequest();
        var todo = await _service.UpdateAsync(request);
        return todo is null ? NotFound() : Ok(todo);
    }

    [HttpPost("{id}/complete")]
    public async Task<IActionResult> Complete(int id)
    {
        var todo = await _service.CompleteAsync(new CompleteTodoRequest(id));
        return todo is null ? NotFound() : Ok(todo);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _service.DeleteAsync(id);
        return NoContent();
    }
}
