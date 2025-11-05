using EmployeeAPI.Middlewares;
using Microsoft.EntityFrameworkCore;
using Repository;
using Repository.Context;
using Services;

var builder = WebApplication.CreateBuilder(args);

// ? Register CORS policy
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngularClient", policy =>
    {
        policy.WithOrigins("http://localhost:4200")  // Your Angular app URL
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

// Add services to the container
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<IEmployeeService, EmployeeService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<EmployeeDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<GlobalExceptionMiddleware>();

app.UseHttpsRedirection();

// ? Enable the CORS policy here (before Authorization)
app.UseCors("AllowAngularClient");

app.UseAuthorization();

app.MapControllers();

app.Run();
