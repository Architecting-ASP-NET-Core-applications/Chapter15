var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

//app.UseExceptionHandler("/Error");
app.UseExceptionHandler("/Home/Error");
app.Map("/Error", async context =>
{
    context.Response.ContentType = "text/html";
    await context.Response
        .WriteAsync("<h1>An unexpected error occurred</h1>");
});


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
