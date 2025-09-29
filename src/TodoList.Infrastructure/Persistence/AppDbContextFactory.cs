using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace TodoList.Infrastructure.Persistence
{
    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();

            // 여기서 런타임과 같은 설정 (SQLite 예시)
            optionsBuilder.UseSqlite("Data Source=todo.db");

            return new AppDbContext(optionsBuilder.Options);
        }
    }
}
