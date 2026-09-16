Console.OutputEncoding = System.Text.Encoding.UTF8;

var builder = DistributedApplication.CreateBuilder(args);

var apiService = builder.AddProject<Projects.InfoManager_Api>("apiservice")
    .WithHttpHealthCheck("/health");

builder.AddProject<Projects.InfoManager_Web>("webfrontend")
    .WithExternalHttpEndpoints()
    .WithHttpHealthCheck("/health")
    .WithReference(apiService)
    .WaitFor(apiService);
builder.Build().Run();