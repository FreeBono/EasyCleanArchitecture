using TodoList.Application.Dtos;
using TodoList.Application.Requests;

public interface ITodoService
{
    Task<TodoDto> CreateAsync(CreateTodoRequest request);
    Task<IEnumerable<TodoDto>> GetAllAsync();
    Task<TodoDto?> GetByIdAsync(int id);
    Task<TodoDto?> UpdateAsync(UpdateTodoRequest request);
    Task<TodoDto?> CompleteAsync(CompleteTodoRequest request);
    Task DeleteAsync(int id);
}
