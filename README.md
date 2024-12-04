<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/897980063/24.2.2%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/T1266420)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
[![](https://img.shields.io/badge/💬_Leave_Feedback-feecdd?style=flat-square)](#does-this-example-address-your-development-requirementsobjectives)
<!-- default badges end -->
# Reporting for Web - Integrate .NET Aspire Dashboard to the ASP.NET Core Reporting App

This example shows a .NET Aspire Dashboard integrated into an ASP.NET Core Document Viewer application.

## Prerequisites

To work with .NET Aspire, you need the following:

* [.NET 8.0](https://dotnet.microsoft.com/download/dotnet/8.0) or [.NET 9.0](https://dotnet.microsoft.com/download/dotnet/9.0)
* [.NET Aspire SDK](https://learn.microsoft.com/en-us/dotnet/aspire/fundamentals/dotnet-aspire-sdk)
* Visual Studio 2022 version 17.9+
* .NET Aspire Dashboard application. Refer to the following help topic for information on how to create the application: [Quick Start: Build your first .NET Aspire solution](https://learn.microsoft.com/en-us/dotnet/aspire/get-started/build-your-first-aspire-app?pivots=visual-studio)
* DevExpress Reports-powered application. Refer to the following section for tutorials on how to create an ASP.NET Core Report Viewer: [Use Reporting Components](https://docs.devexpress.com/XtraReports/119717/web-reporting/aspnet-core-reporting#use-reporting-components)

### Add DevExpress NuGet Packages

Reference the following NuGet packages in your Reporting application:

* `DevExpress.Aspire.Reporting`
* `DevExpress.Aspire.AspNetCore.Reporting`

## Implementation Details

Add the following project references:

| Project | Reference |
| --- | --- |
| **AppHost/Orchestration** project (usually with an _*.AppHost_ suffix) | **DevExpress Reports** application |
| **DevExpress Reports** application |  **ServiceDefaults** application |

Open your reporting project. Add the following method calls to `Program.cs`:

# [Program.cs](#tab/tabid-csharp)

```csharp
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDevExpressControls();
// Important note: Enable .NET Aspire integration after an AddDevExpressControls method call
// Enable service discovery and configure OpenTelemetry metrics and tracing for .NET Aspire.
// Learn more at: https://learn.microsoft.com/en-us/dotnet/aspire/fundamentals/service-defaults
builder.AddServiceDefaults();

// Share trace data with the .NET Aspire Dashboard from DevExpress Reports document creation and exporting
builder.AddReporting();
// Share trace and metrics data with the .NET Aspire Dashboard for the DevExpress Reports back end services
builder.AddAspNetCoreReporting();
```

***

Navigate to the `AppHost` project. Add the following project reference code to `Program.cs`:

# [Program.cs](#tab/tabid-csharp)

```csharp
var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.DevExpressReportingApp>("webreporting")
  .WithExternalHttpEndpoints();

builder.Build().Run();
```

***

## Files to Review

* [DevExpressReportingApp.Program.cs](./CS/AspireStarterApp/DevExpressReportingApp/Program.cs)
* [AspireStarterApp.AppHost.Program.cs](./CS/AspireStarterApp/AspireStarterApp.AppHost/Program.cs)


<!-- feedback -->
## Does this example address your development requirements/objectives?

[<img src="https://www.devexpress.com/support/examples/i/yes-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=reporting-asp-net-core-aspire&~~~was_helpful=yes) [<img src="https://www.devexpress.com/support/examples/i/no-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=reporting-asp-net-core-aspire&~~~was_helpful=no)

(you will be redirected to DevExpress.com to submit your response)
<!-- feedback end -->
