
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RentCar.Application.Intefaces;
using RentCar.Infrastructure.Data;
using RentCar.Infrastructure.Repositories;
using Microsoft.Extensions.Configuration;

namespace RentCar.Infrastructure;
public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, ConfigurationManager configuration)
    {

        services.AddDbContext<RentCarDbContext>(options => 
            options.UseInMemoryDatabase("RentCarDB")
        );
        services.AddScoped<IManufacturerRepository, ManufacturerRepository>();
        services.AddScoped<IVehicleModelRepository, VehicleModelRepository>();
        services.AddScoped<IVehicleRepository, VehicleRepository>();
        services.AddScoped<IOfficeRepository, OfficeRepository>();


        return services;
    }

}
