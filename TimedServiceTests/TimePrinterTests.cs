namespace TimedServiceTests;

using FakeItEasy;
using NLog;
using TimedServiceApp;

public class TimePrinterTests
{
    [Fact]
    public void PrintCurrentTime_LogsCurrentTime()
    {
        // Arrange
        var logger = A.Fake<ILogger>();
        var timePrinter = new TimePrinter(logger);

        // Act
        timePrinter.PrintCurrentTime();

        // Assert
        A.CallTo(() => logger.Info(A<string>.That.Contains("Current time"), A<DateTime>._))
            .MustHaveHappenedOnceExactly();
    }
}