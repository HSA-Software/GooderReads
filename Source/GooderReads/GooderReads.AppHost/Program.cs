var builder = DistributedApplication.CreateBuilder(args);

var sql = builder.AddPostgres("sql")
    .WithDataVolume()
    .WithPgAdmin();

var sqldb = sql.AddDatabase("GooderReadsSQL");

var cache = builder.AddRedis("cache");

var apiService = builder.AddProject<Projects.GooderReads_ApiService>("apiservice")
    .WithReference(sqldb);

builder.AddProject<Projects.GooderReads_Web>("webfrontend")
    .WithExternalHttpEndpoints()
    .WithReference(cache)
    .WithReference(apiService);

builder.Build().Run();
