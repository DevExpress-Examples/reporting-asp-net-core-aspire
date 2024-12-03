var builder = DistributedApplication.CreateBuilder(args);

var apiService = builder.AddProject<Projects.AspireStarterApp_ApiService>("apiservice");

builder.AddProject<Projects.AspireStarterApp_Web>("webfrontend")
    .WithExternalHttpEndpoints()
    .WithReference(apiService);

builder.AddProject<Projects.DevExpressReportingApp>("webreporting")
    .WithExternalHttpEndpoints();

builder.Build().Run();
