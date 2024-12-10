# Timed Hosted Service Application

This repository contains a C# application that implements a timed background service using .NET's generic host and **BackgroundService**. The application is designed to periodically print the current time using a service that runs in the background. The solution is fully tested, achieving 100% code coverage.

## Features

- **Timed Hosted Service**: A background service that executes a task at regular intervals.
- **Dependency Injection**: Utilizes .NET's built-in dependency injection for service management.
- **Logging**: Integrates with NLog for logging service activities and errors.
- **Unit and Integration Tests**: Comprehensive test suite using xUnit, FakeItEasy, and FluentAssertions.
- **Code Coverage**: 100%

## Project Structure

- **TimedServiceApp**: Contains the main application code, including the `TimedHostedService` and `TimePrinter` classes.
- **TimedServiceTests**: Contains unit and integration tests for the application, ensuring all components work as expected.

## Getting Started

### Prerequisites

- [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [NLog](https://nlog-project.org/) for logging
- [FakeItEasy](https://fakeiteasy.github.io/) for mocking in tests
- [FluentAssertions](https://fluentassertions.com/) for expressive assertions in tests

 
### Building the Project

1. **Clone the repository**:
   Open your terminal and run the following command to clone the repository:
   ```bash
   git clone https://github.com/LegacyOfKain/TimedHostedServiceApp.git
   ```

2. **Navigate to the project directory**:
   Change into the project directory:
   ```bash
   cd TimedHostedServiceApp
   ```

3. **Build the project**:
   Use the .NET CLI to build the project:
   ```bash
   dotnet build
   ```

4. **Run the application**:
   Execute the application using the .NET CLI:
   ```bash
   dotnet run --project TimedServiceApp
   ```

5. **Run the tests**:
   Execute the test suite to ensure everything is working correctly:
   ```bash
   dotnet test
   ```

6. **Generate code coverage report**:
   Run the tests with code coverage collection:
   ```bash
   dotnet test --collect:"XPlat Code Coverage"
   ```

### Code Coverage

This project achieves 100% code coverage, ensuring that all code paths are tested. To generate a code coverage report, use the following command:  
> [!IMPORTANT]
> The Main method is **excluded** from code coverage analysis using the **[ExcludeFromCodeCoverage]** attribute.  
This is a common practice for entry-point methods, as they typically contain boilerplate code that doesn't require testing.

You can view the coverage report in the `CoverageReport` directory after running the `run_CodeCoverage.bat` script.

## License

This project is licensed under the [MIT License](https://opensource.org/licenses/MIT).

## Acknowledgments

- Thanks to the .NET community for providing excellent tools and libraries that make development easier.
- Special thanks to the authors of NLog, FakeItEasy, and FluentAssertions for their invaluable contributions to the .NET ecosystem.
