

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RentCar.Application.Helpers;

namespace RentCar.Application;
public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services, ConfigurationManager configuration)
    {
        services.AddAutoMapper(typeof(MappingProfiles).Assembly);
        return services;
    }
}
