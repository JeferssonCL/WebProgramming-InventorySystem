using Backend.Application;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

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



/* 
TODO: Configure Database
builder.Services.AddDbContext<PostgresContext>(options =>
               options.UseNpgsql(builder.Configuration.GetConnectionString("ContextDb"))
           ); 
*/

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

app.UseStatusCodePages();
app.UseExceptionHandler();

app.UseHttpsRedirection();
app.UseCors("AllowLocalhost");
app.UseAuthorization();
app.MapControllers();

app.Run();
