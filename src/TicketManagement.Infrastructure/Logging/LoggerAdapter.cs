using Microsoft.Extensions.Logging;
using TicketManagement.Application.Contracts.Logging;

namespace TicketManagement.Infrastructure.Logging;

public class LoggerAdapter<T>(ILoggerFactory loggerFactory) : IAppLogger<T>
{
    private readonly ILogger<T> _logger = loggerFactory.CreateLogger<T>();

    public void LogInformation(string message, params object[] args)
    {
        _logger.LogInformation(message, args);
    }

    public void LogWarning(string message, params object[] args)
    {
       _logger.LogWarning(message, args);
    }
}