namespace TodoList.Application.Dtos;

public record TodoDto(
    int Id,
    string Title,
    bool IsCompleted,
    DateTime CreatedAt,
    DateTime? CompletedAt,
    DateTime DueDate
);
