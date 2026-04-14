using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace fiap_azure_gitactions_azure_function;

public class ShowMessageTimer
{
    private readonly ILogger _logger;

    public ShowMessageTimer(ILoggerFactory loggerFactory)
    {
        _logger = loggerFactory.CreateLogger<ShowMessageTimer>();
    }

    [Function("ShowMessageTimer")]
    public void Run([TimerTrigger("0 */5 * * * *")] TimerInfo timerInfo)
    {
        var message = Environment.GetEnvironmentVariable("MY_MESSAGE");

        _logger.LogInformation("Timer executed at: {time}", DateTime.Now);
        _logger.LogInformation("Message: {message}", message ?? "MY_MESSAGE not set");
    }
}