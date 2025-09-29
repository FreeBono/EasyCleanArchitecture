using TodoList.Domain.ValueObjects;

namespace TodoList.Domain.Entities;

public class TodoItem
{
    public int Id { get; private set; } // DB에서 자동 증가 (PK)
    public string Title { get; private set; }
    public bool IsCompleted { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime? CompletedAt { get; private set; }
    public DueDate DueDate { get; private set; }   // 값 객체(Value Object) 사용 

    private TodoItem() { } // EF Core용 프라이빗 생성자

    public TodoItem(string title, DueDate dueDate)
    {
        Title = title ?? throw new ArgumentNullException(nameof(title));
        DueDate = dueDate ?? throw new ArgumentNullException(nameof(dueDate));
        CreatedAt = DateTime.UtcNow;
        IsCompleted = false;
    }

    public void Complete()
    {
        if (IsCompleted)
            throw new InvalidOperationException("이미 완료된 항목입니다.");

        IsCompleted = true;
        CompletedAt = DateTime.UtcNow;
    }

    public void UpdateTitle(string title) => Title = title;
    public void UpdateDueDate(DueDate dueDate) => DueDate = dueDate;
}
