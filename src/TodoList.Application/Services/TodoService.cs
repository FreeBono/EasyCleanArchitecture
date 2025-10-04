using TodoList.Application.Common.Logging;
using TodoList.Application.Dtos;
using TodoList.Application.Interfaces;
using TodoList.Application.Requests;
using TodoList.Domain.Entities;
using TodoList.Domain.ValueObjects;
using TodoList.Application.Common.Exceptions;

namespace TodoList.Application.Services;

public class TodoService : ITodoService
{
    private readonly ITodoRepository _repository;
    private readonly IAppLogger<TodoService> _logger;

    public TodoService(ITodoRepository repository, IAppLogger<TodoService> logger)
    {
        _repository = repository;
        _logger = logger;
    }

    public async Task<TodoDto> CreateAsync(CreateTodoRequest request)
    {
        var todo = new TodoItem(request.Title, new DueDate(request.DueDate));
        await _repository.AddAsync(todo);
        return ToDto(todo);
    }

    public async Task<IEnumerable<TodoDto>> GetAllAsync()
    {
        _logger.LogInformation("Fetching all todo items.");
        var todos = await _repository.GetAllAsync();
        return todos.Select(ToDto);
    }

    public async Task<TodoDto?> GetByIdAsync(int id)
    {
        var todo = await _repository.GetByIdAsync(id);
        if (todo == null)
            throw new NotFoundException("Todo", id);
        
        return ToDto(todo);
    }

    public async Task<TodoDto?> UpdateAsync(UpdateTodoRequest request)
    {
        var todo = await _repository.GetByIdAsync(request.Id);
        if (todo == null) return null;

        // EF Core 추적 객체 업데이트
        todo.UpdateTitle(request.Title);
        todo.UpdateDueDate(new DueDate(request.DueDate));

        await _repository.UpdateAsync(todo);
        return ToDto(todo);
    }

    public async Task<TodoDto?> CompleteAsync(CompleteTodoRequest request)
    {
        var todo = await _repository.GetByIdAsync(request.Id);
        if (todo == null) return null;

        todo.Complete();
        await _repository.UpdateAsync(todo);

        return ToDto(todo);
    }

    public async Task DeleteAsync(int id) => await _repository.DeleteAsync(id);

    private static TodoDto ToDto(TodoItem todo) =>
        new(todo.Id, todo.Title, todo.IsCompleted, todo.CreatedAt, todo.CompletedAt, todo.DueDate.Value, todo.IsExpired);
}