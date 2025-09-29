namespace TodoList.Application.Requests;

public record UpdateTodoRequest(int Id, string Title, DateTime DueDate);
