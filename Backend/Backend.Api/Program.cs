using Backend.Application;
using Backend.Domain.Entities.Concretes;
using Backend.Infrastructure.Context;
using Backend.Infrastructure.DAO.Concretes;
using Backend.Infrastructure.DAO.Interfaces;
using DotNetEnv;
using MediatR;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

Env.Load("../.env");

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowLocalhost",
        builder => builder.WithOrigins("http://localhost:5173")
                          .AllowAnyHeader()
                          .AllowAnyMethod());
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

// CHECK:Add services to the container.
builder.Services.AddApplication();

builder.Services.AddScoped<IGenericDAO<Product>, ProductDAO>();


builder.Services.AddDbContext<PostgresContext>(options =>
    options.UseNpgsql(Environment.GetEnvironmentVariable("POSTGRES_CONNECTION_STRING"))
           .EnableSensitiveDataLogging()
           .LogTo(Console.WriteLine, LogLevel.Information)
);
// Register application services

builder.Services.AddMediatR(cfg =>
            cfg.RegisterServicesFromAssemblies(typeof(ApplicationProfile).Assembly)
        );

builder.Services.AddAutoMapper(typeof(ApplicationProfile).Assembly);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();
app.UseCors("AllowLocalhost");
app.UseAuthorization();
app.MapControllers();

app.Run();
