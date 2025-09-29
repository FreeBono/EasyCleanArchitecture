namespace TodoList.Domain.ValueObjects;

public record DueDate
{
    public DateTime Value { get; }

    public DueDate(DateTime value)
    {
        if (value < DateTime.UtcNow.Date)
            throw new ArgumentException("마감일은 현재 날짜 이후여야 합니다.");

        Value = value;
    }
}
