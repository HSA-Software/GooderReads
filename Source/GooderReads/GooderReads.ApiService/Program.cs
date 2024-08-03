using GooderReads.ApiService;
using GooderReads.ApiService.FakeDatabase;
using GooderReads.ApiService.Mutations;

var builder = WebApplication.CreateBuilder(args);

// Add service defaults & Aspire components.
builder.AddServiceDefaults();

// Add services to the container.
builder.Services.AddProblemDetails();
builder.AddNpgsqlDbContext<GooderReadsContext>("GooderReadsSQL");

builder.Services
    .AddGraphQLServer()
    .AddProjections()
    .RegisterDbContext<GooderReadsContext>()
    .AddQueryType<BooksQuery>()
    .AddMutationType<BooksMutation>();

builder.Services.AddHostedService<Migrator>();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseExceptionHandler();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
{
    var forecast = Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
});

app.MapGet("/books/fake", () => 
{
    var books = FakeBooks.GenerateBooks(100);

    return books;
});

app.MapGraphQL();
app.MapBananaCakePop();
app.MapDefaultEndpoints();

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
