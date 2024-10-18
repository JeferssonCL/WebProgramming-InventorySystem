using Backend.Api;
using Microsoft.AspNetCore.Diagnostics;
using DotNetEnv;
using Microsoft.EntityFrameworkCore;
using Backend.Application;
using Backend.Infrastructure.Context;
using Backend.Infrastructure.Repositories.Interfaces;
using Backend.Infrastructure.Repositories.Concretes;
using Backend.Application.Repositories.Concretes;

var builder = WebApplication.CreateBuilder(args);

Env.Load("../.env");

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowLocalhost",
        builder => builder.WithOrigins("*")
                          .AllowAnyHeader()
                          .AllowAnyMethod());
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.CustomSchemaIds(type => type.FullName);
});
builder.Configuration.AddEnvironmentVariables();

builder.Services.AddApplication();



builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

string connectionString = Env.GetString("POSTGRESSQLCONNECTION");

builder.Services.AddDbContext<DbContext, PostgresContext>(options =>
    options.UseNpgsql(connectionString,
        b => b.MigrationsAssembly("Backend.Api"))

           .EnableSensitiveDataLogging()
           .LogTo(Console.WriteLine, LogLevel.Information)
);

builder.Services.AddAuthorization();
builder.Services.AddControllers();
builder.Services.AddSingleton<IExceptionHandler, GlobalExceptionHandler>();
builder.Services.AddSwaggerAuthConfig();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseExceptionHandler("/error");
}


app.UseHttpsRedirection();
app.UseCors("AllowLocalhost");
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
