using Backend.Application;
using Backend.Domain.Entities.Concretes;
using Backend.Infrastructure.Context;
using Backend.Infrastructure.DAO.Concretes;
using Backend.Infrastructure.DAO.Interfaces;
using DotNetEnv;
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
builder.Configuration.AddEnvironmentVariables();

// CHECK:Add services to the container.
builder.Services.AddApplication();


builder.Services.AddScoped<IGenericDAO<Product>, ProductDAO>();
builder.Services.AddScoped<IGenericDAO<Order>, OrderDAO>();

string connectionString = builder.Configuration["PostgresSQLConnection"]
    ?? throw new Exception("POSTGRES_CONNECTION_STRING is not set");

builder.Services.AddDbContext<PostgresContext>(options =>
    options.UseNpgsql(connectionString,
        b => b.MigrationsAssembly("Backend.Api"))

           .EnableSensitiveDataLogging()
           .LogTo(Console.WriteLine, LogLevel.Information)
);

builder.Services.AddAuthorization();
builder.Services.AddControllers();
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
