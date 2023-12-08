using DealershipManagementSystem.Entities.Car;
using Microsoft.EntityFrameworkCore;
using DealershipManagementSystem.Repository;


var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;//get config from appstettings.json
// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(configuration.GetConnectionString("ConnectionString")));
//builder.Services.AddScoped<ICarRepository,CarRepository>();
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

app.Run();