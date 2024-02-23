using Autoverleih_Backend.Db.Data;
using Autoverleih_Backend.Services;
using Microsoft.EntityFrameworkCore;
using urlaubsplanungstool_backend.Db.Repositories;

var builder = WebApplication.CreateBuilder(args);
var dbConnectionString = builder.Configuration["ConnectionString"];

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    {
        options.UseNpgsql(dbConnectionString);
    }
);

builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IAuthService, AuthService>();

builder.Services.AddAutoMapper(typeof(Autoverleih_Backend.Common.AutoMapper));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}