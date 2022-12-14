using Microsoft.Extensions.DependencyInjection;
using Server.Domain.Vehicle;
using Server.Infrasctucture.Vehicle;


namespace Server.Infrasctucture
{
    public static class InfrastructureServiceCollectionExtension
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {

            // Repositories
            services.AddScoped<IVehicleRepositroy, VehicleRepository>();
            return services;
        }
    }
}
