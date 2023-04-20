

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RentCar.Application.Helpers;
using RentCar.Application.Intefaces.Services;
using RentCar.Application.Services;

namespace RentCar.Application;
public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services, ConfigurationManager configuration)
    {
        services.AddAutoMapper(typeof(MappingProfiles).Assembly);
        services.AddScoped<IManufacturerService, ManufacturerService>();
        services.AddMemoryCache();
        return services;
    }
}
