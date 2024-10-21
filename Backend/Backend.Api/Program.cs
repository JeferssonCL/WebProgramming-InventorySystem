using Backend.Application;
using Backend.Infrastructure.Context;
using Backend.Infrastructure.Repositories.Concretes;
using Backend.Infrastructure.Repositories.Interfaces;
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
builder.Services.AddSwaggerGen(c =>
{
    c.CustomSchemaIds(type => type.FullName);
});
builder.Configuration.AddEnvironmentVariables();

builder.Services.AddApplication();


builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IUserAddressRepository, UserAddressRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IPaymentTransactionRepository, PaymentTransactionRepository>();
builder.Services.AddScoped<IOrderItemRepository, OrderItemRepository>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();


string connectionString = Env.GetString("POSTGRESSQLCONNECTION");

builder.Services.AddDbContext<DbContext, PostgresContext>(options =>
    options.UseNpgsql(connectionString,
            b => b.MigrationsAssembly("Backend.Api"))
        .EnableSensitiveDataLogging()
        .LogTo(Console.WriteLine, LogLevel.Information)
);

builder.Services.AddAuthorization();
builder.Services.AddControllers();


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
