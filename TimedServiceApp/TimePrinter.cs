using NLog;

namespace TimedServiceApp;

public class TimePrinter : ITimePrinter
{
    private readonly ILogger _logger;

    public TimePrinter(ILogger logger)
    {
        _logger = logger;
    }

    public void PrintCurrentTime()
    {
        _logger.Info("Current time: {0}",DateTime.Now);
    }
}
