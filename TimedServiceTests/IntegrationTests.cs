using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Xunit;
using TimedServiceApp;
using FakeItEasy;
using NLog;
using FluentAssertions;

namespace TimedServiceTests
{
    public class IntegrationTests
    {
        [Fact]
        public async Task Application_StartsAndRunsSuccessfully()
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

            using var host = hostBuilder.Build();

            // Start the host
            await host.StartAsync();

            // Assert
            var services = host.Services;
            var hostedService = services.GetService<IHostedService>();
            hostedService.Should().NotBeNull();
            hostedService.Should().BeOfType<TimedHostedService>();

            // Stop the host
            await host.StopAsync();
        }
    }
}