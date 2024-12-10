namespace TimedServiceApp;

using Microsoft.Extensions.Hosting;
using NLog;

public class TimedHostedService : BackgroundService
{
    private readonly ITimePrinter _timePrinter;
    private readonly ILogger _logger;

    public TimedHostedService(ITimePrinter timePrinter, ILogger logger)
    {
        _timePrinter = timePrinter;
        _logger = logger ;
    }

    public void DoWork()
    {
        try
        {
            _timePrinter.PrintCurrentTime();
        }
        catch (Exception ex)
        {
            _logger.Error(ex, "An error occurred while printing the time.");
        }
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        // Log the "running" message
        _logger.Debug("Service is starting...");

        while (!stoppingToken.IsCancellationRequested)
        {
            // Perform the work here and check for stoppingToken.IsCancellationRequested regularly
            // If the work is I/O bound and supports cancellation, pass the stoppingToken to it.
            try
            {
                DoWork();
                await Task.Delay(100, stoppingToken);

            }
            catch (OperationCanceledException)
            {
                // This is thrown if the task is cancelled, break the loop or handle it if necessary
                break;
            }

            // Log the "running" message
            _logger.Debug("Service is running...");
        }

        // Log the "stopping" message
        _logger.Debug("Service is stopping...");
    }
}