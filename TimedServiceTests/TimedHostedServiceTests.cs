namespace TimedServiceTests;

using FakeItEasy;
using NLog;
using TimedServiceApp;

public class TimedHostedServiceTests
{
    [Fact]
    public async Task StartAsync_And_StopAsync_Log_Information_When_Service_Starts_And_Stops()
    {
        // Arrange
        var timePrinter = A.Fake<ITimePrinter>();
        var logger = A.Fake<ILogger>();
        var service = new TimedHostedService(timePrinter, logger);

        // Act - Start the service
        await service.StartAsync(CancellationToken.None);

        // Wait for a moment to let the service run
        await Task.Delay(1100);  // Wait slightly more than 1 second

        // Assert that service logs "starting" message
        A.CallTo(() => logger.Debug(A<string>.That.Contains("starting")))
            .MustHaveHappenedOnceExactly();

        // Assert that service logs "starting" message
        A.CallTo(() => logger.Debug(A<string>.That.Contains("running")))
            .MustHaveHappenedOnceOrMore();

        // Assert that TimePrinter was called at least once
        A.CallTo(() => timePrinter.PrintCurrentTime()).MustHaveHappenedOnceOrMore();

        // Act - Stop the service
        await service.StopAsync(CancellationToken.None);

        // Assert that service logs "stopping" message
        A.CallTo(() => logger.Debug(A<string>.That.Contains("stopping")))
            .MustHaveHappenedOnceExactly();
    }

    [Fact]
    public void DoWork_LogsError_WhenExceptionOccurs()
    {
        // Arrange
        var timePrinter = A.Fake<ITimePrinter>();
        var logger = A.Fake<ILogger>();
        var service = new TimedHostedService(timePrinter, logger);

        // Setup timePrinter to throw an exception
        A.CallTo(() => timePrinter.PrintCurrentTime()).Throws<Exception>();

        // Act
        service.DoWork();

        // Assert
        A.CallTo(() => logger.Error(A<Exception>._, A<string>.That.Contains("An error occurred while printing the time")))
            .MustHaveHappenedOnceExactly();
    }
}