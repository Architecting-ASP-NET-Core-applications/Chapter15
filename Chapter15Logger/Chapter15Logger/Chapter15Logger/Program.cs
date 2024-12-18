using Serilog;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

// Serilog configuration
Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Debug() // Set minimum log level
    .WriteTo.Console() // Log to console
    .WriteTo.File("logs/log-.txt"
        , rollingInterval: RollingInterval.Day)
    .CreateLogger();

await using var log = new LoggerConfiguration()
    .WriteTo.Email(
        from: "sender@example.com",
        to: "receiver@example.example",
        host: "smtp.example.com")
    .CreateLogger();

var app = builder.Build();
app.UseRouting();

app.MapControllers();

app.Run();




