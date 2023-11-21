using FootballTicketManagement.Application.Contracts.Logging;
using Microsoft.Extensions.Logging;

namespace FootballTicketManagement.Infrastructure.Logging;

public class LoggerAdapter<T> : IAppLoger<T>
{
    private readonly ILogger<T> _logger;

    public LoggerAdapter(ILoggerFactory loggerFactory)
    {
        _logger = loggerFactory.CreateLogger<T>();
    }
    
    public void LogInformation(string message, params object[] args)
    {
        _logger.LogInformation(message, args);
    }

    public void LogWarning(string message, params object[] args)
    {
       _logger.LogWarning(message, args);
    }
}