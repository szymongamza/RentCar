
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RentCar.Infrastructure.Data;
using RentCar.Infrastructure.Repositories;
using Microsoft.Extensions.Configuration;
using RentCar.Application.Interfaces.Repositories;
using RentCar.Application.Interfaces.Services;
using RentCar.Infrastructure.Services;

namespace RentCar.Infrastructure;
public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, ConfigurationManager configuration)
    {

        services.AddDbContext<RentCarDbContext>(options =>
            options.UseSqlite(configuration.GetConnectionString("RentCarDatabase")));
        services.AddScoped<IManufacturerRepository, ManufacturerRepository>();
        services.AddScoped<IVehicleModelRepository, VehicleModelRepository>();
        services.AddScoped<IVehicleRepository, VehicleRepository>();
        services.AddScoped<IOfficeRepository, OfficeRepository>();

        services.AddScoped<IManufacturerService, ManufacturerService>();
        services.AddScoped<IVehicleModelService, VehicleModelService>();
        services.AddMemoryCache();




        return services;
    }

}
