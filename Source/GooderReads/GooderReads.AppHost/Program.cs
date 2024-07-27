var builder = DistributedApplication.CreateBuilder(args);

var cache = builder.AddRedis("cache");
var mongo = builder.AddMongoDB("db")
    .WithMongoExpress()
    .AddDatabase("test");

var apiService = builder.AddProject<Projects.GooderReads_ApiService>("apiservice")
    .WithReference(mongo);

builder.AddProject<Projects.GooderReads_Web>("webfrontend")
    .WithExternalHttpEndpoints()
    .WithReference(cache)
    .WithReference(apiService);

builder.Build().Run();
