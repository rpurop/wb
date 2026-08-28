using Microsoft.EntityFrameworkCore;
using WBTask.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddDbContext<WBTaskContext>(opt =>
    opt.UseInMemoryDatabase("WBTask"));


var app = builder.Build();

DatabaseInitilaizer.Seed(app);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUi(options =>
    {
        options.DocumentPath = "/openapi/v1.json";
    });
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();


// app.MapGet("/test", (HttpContext context) =>
// {
//     var userRole = context.Request.Headers["x-user-role"];
//     if (userRole == "Admin")
//     {
//         return Results.Ok("Admin");
//     }
//     return Results.Unauthorized();
// });

app.Run();


