namespace FootballTicketManagement.Application.Contracts.Logging;

public interface IAppLoger<T>
{
    void LogInformation(string message, params object[] args);
    void LogWarning(string message, params object[] args);
    
}