using TodoList.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace TodoList.Infrastructure.Persistence;

public class AppDbContext : DbContext // EF Core에서 ORM(객체-관계 매핑)을 지원
{
    public DbSet<TodoItem> Todos => Set<TodoItem>();
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TodoItem>(entity =>
        {
            entity.HasKey(t => t.Id);
            entity.OwnsOne(t => t.DueDate, dueDate =>
            {
                dueDate.Property(d => d.Value)
                    .HasColumnName("DueDate")
                    .IsRequired();
            });
        });
    }
}
