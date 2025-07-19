using api.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using api.Controllers;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "FinShark API", Version = "v1" });
});
builder.Services.AddControllers()
    .AddApplicationPart(typeof(StockController).Assembly);

builder.Services.AddDbContext<ApplicationDBContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();



var controllerTypes = typeof(Program).Assembly.GetTypes()
    .Where(t => typeof(ControllerBase).IsAssignableFrom(t) && !t.IsAbstract)
    .Select(t => t.FullName);
Console.WriteLine("Контроллеры в сборке:");
foreach (var name in controllerTypes)
    Console.WriteLine(name);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => 
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "FinShark API V1");
    });
}
app.UseHttpsRedirection();
app.MapControllers();
app.Run();

