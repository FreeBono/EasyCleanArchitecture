using TodoList.Domain.Entities;

namespace TodoList.Application.Interfaces;

public interface ITodoRepository
{
    Task AddAsync(TodoItem todo);
    Task<IEnumerable<TodoItem>> GetAllAsync();
    Task<TodoItem?> GetByIdAsync(int id);
    Task UpdateAsync(TodoItem todo);
    Task DeleteAsync(int id);
}
