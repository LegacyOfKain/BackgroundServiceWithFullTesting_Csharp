using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Diagnostics.CodeAnalysis; // Add this using directive

namespace TimedServiceApp;
public static class Program
{
    // Yes, you can exclude the Main method from code coverage analysis.
    // This is common practice for entry-point methods,
    // as they typically contain boilerplate code that doesn't require testing. 
    [ExcludeFromCodeCoverage] // Add this attribute
    public static void Main(string[] args)
    {
        CreateHostBuilder(args).Build().Run();
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureServices((hostContext, services) =>
            {
                services.AddHostedService<TimedHostedService>();
                services.AddSingleton<ITimePrinter, TimePrinter>();
                // Add other services and configurations if needed
            });
}