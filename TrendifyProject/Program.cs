using Microsoft.EntityFrameworkCore;
using System;
using TrendifyProject.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins", builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});

var connection = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<TrendifyDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString(connection)));
var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
await using var scope = app.Services.CreateAsyncScope();
using var db = scope.ServiceProvider.GetService<TrendifyDbContext>();
//await db.Database.MigrateAsync();

app.Run();
