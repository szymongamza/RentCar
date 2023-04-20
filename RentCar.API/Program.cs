using Microsoft.OpenApi.Models;
using RentCar.API.Helpers;
using RentCar.API.Services;
using RentCar.Application;
using RentCar.Application.Interfaces.Services;
using RentCar.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddApplication(builder.Configuration);
builder.Services.AddScoped<IManufacturerService, ManufacturerService>();
builder.Services.AddScoped<IVehicleModelService, VehicleModelService>();
builder.Services.AddMemoryCache();
builder.Services.AddAutoMapper(typeof(ApiMappingProfiles).Assembly);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "RentCar", Version = "v1", Description = "API for renting car" })
);

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
