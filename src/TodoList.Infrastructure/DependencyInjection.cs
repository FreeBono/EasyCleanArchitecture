using TodoList.Application.Interfaces;

using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using TodoList.Infrastructure.Persistence;
using TodoList.Infrastructure.Repositories;
namespace Microsoft.Extensions.DependencyInjection;

public static class DependencyInjection
{
  public static void AddInfrastructureServices(this IHostApplicationBuilder builder)
  {
      // 1. DbContext 등록 (SQLite 예시)
      builder.Services.AddDbContext<AppDbContext>(options =>
          options.UseSqlite("Data Source=todo.db"));
      // 2. Repository 등록
      builder.Services.AddScoped<ITodoRepository, TodoRepository>();
  }
}

