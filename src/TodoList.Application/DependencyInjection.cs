// TodoList.Application/DependencyInjection.cs
using TodoList.Application.Services;
using Microsoft.Extensions.Hosting;
namespace Microsoft.Extensions.DependencyInjection;

public static class DependencyInjection
{
    public static void AddApplicationServices(this IHostApplicationBuilder builder)
    {
        builder.Services.AddScoped<ITodoService, TodoService>();
    }
}

