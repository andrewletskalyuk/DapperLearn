var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.DapperLearn>("dapperlearn");

builder.Build().Run();
