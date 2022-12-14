using Microsoft.Extensions.DependencyInjection;
using Server.Service.Vehicle;

namespace Server.Service
{
    public static class ServicesServiceCollectionExtension
    {
        public static IServiceCollection AddServiceServices(this IServiceCollection services)
        {
            //repositories
            services.AddScoped<IVehicleService, VehicleService>();

            return services;
        }
    }
}
