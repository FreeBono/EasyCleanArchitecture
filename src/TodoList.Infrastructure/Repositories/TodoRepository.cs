
using TodoList.Domain.Entities;
using TodoList.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using TodoList.Application.Interfaces;

namespace TodoList.Infrastructure.Repositories;

public class TodoRepository : ITodoRepository
{
    private readonly AppDbContext _context;

    public TodoRepository(AppDbContext context) => _context = context;

    public async Task AddAsync(TodoItem todo)
    {
        _context.Todos.Add(todo);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<TodoItem>> GetAllAsync() =>
        await _context.Todos.AsNoTracking().ToListAsync();

    public async Task<TodoItem?> GetByIdAsync(int id) =>
        await _context.Todos.FindAsync(id);

    public async Task UpdateAsync(TodoItem todo)
    {
        _context.Todos.Update(todo);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var todo = await _context.Todos.FindAsync(id);
        if (todo != null)
        {
            _context.Todos.Remove(todo);
            await _context.SaveChangesAsync();
        }
    }
}