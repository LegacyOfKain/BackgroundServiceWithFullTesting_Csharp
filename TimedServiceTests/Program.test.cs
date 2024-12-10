using FakeItEasy;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NLog;
using TimedServiceApp;

namespace TimedServiceTests;
public class ProgramTests
{
    [Fact]
    public void CreateHostBuilder_ConfiguresServicesCorrectly()
    {
        // Arrange
        var args = new string[] { };

        // Act
        var hostBuilder = Program.CreateHostBuilder(args);
        hostBuilder.ConfigureServices(services =>
        {
            // Register a fake logger for testing
            services.AddSingleton(A.Fake<ILogger>());
        });
        var host = hostBuilder.Build();
        var services = host.Services;

        // Assert
        services.GetService<IHostedService>().Should().BeOfType<TimedHostedService>();
        services.GetService<ITimePrinter>().Should().BeOfType<TimePrinter>();
    }
}