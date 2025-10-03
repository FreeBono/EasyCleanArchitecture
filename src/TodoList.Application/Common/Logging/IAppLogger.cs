namespace TodoList.Application.Common.Logging;

public interface IAppLogger<T>
{
    void LogInformation(string message, params object[] args);
    void LogWarning(string messagem, params object[] args);
    void LogError(string message, Exception ex);
}
