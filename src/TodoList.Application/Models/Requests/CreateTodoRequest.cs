namespace TodoList.Application.Requests;

public record CreateTodoRequest(string Title, DateTime DueDate);