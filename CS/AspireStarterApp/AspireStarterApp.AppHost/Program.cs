var builder = DistributedApplication.CreateBuilder(args);

var apiService = builder.AddProject("AspireStarterApp.ApiService", "apiservice");

builder.AddProject("AspireStarterApp.Web", "webfrontend")
    .WithExternalHttpEndpoints()
    .WithReference(apiService);

builder.AddProject("DevExpressReportingApp", "webreporting")
    .WithExternalHttpEndpoints();

builder.Build().Run();
