using mercantil_api.Config;
using mercantil_api.Data;
using mercantil_api.Models.Banks;
using mercantil_api.Models.Payments;
using mercantil_api.Services.Banks;
using mercantil_api.Services.Payments;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(options =>
    {
        options
        .WithOrigins("http://localhost:4200")
        .AllowAnyHeader()
        .WithMethods("GET", "POST", "PUT", "DELETE");
    });
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddDbContext<PaymentContext>((options) =>
{
    options.UseMySql(
        builder
        .Configuration
        .GetConnectionString("MariaDB"),
        new MariaDbServerVersion(new Version("10.11.2.0")));
});

ServicesConfig.InitializeServices(builder);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.CreateDbIfNotExists();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();

app.UseAuthorization();

app.MapControllers();

app.Run();
