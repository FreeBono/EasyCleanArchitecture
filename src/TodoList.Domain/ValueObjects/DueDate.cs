namespace TodoList.Domain.ValueObjects;

public record DueDate
{
    public DateTime Value { get; }

    public DueDate(DateTime value)
    {
        Value = value;
    }
}
