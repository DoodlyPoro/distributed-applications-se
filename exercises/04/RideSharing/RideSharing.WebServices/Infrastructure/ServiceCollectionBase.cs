using Microsoft.EntityFrameworkCore;
using RideSharing.ApplicationServices.Implementations;
using RideSharing.ApplicationServices.Interfaces;
using RideSharing.Data;
using RideSharing.Repositories.Implementations;
using RideSharing.Repositories.Interfaces;
using RideSharing.WebServices.Services;

namespace RideSharing.WebServices.Infrastructure
{
    public static class ServiceCollectionBase
    {
        public static IServiceCollection AddDatabaseRideContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<RideSharingDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"), x => x.MigrationsAssembly("RideSharing.WebServices")));
            services.AddScoped<IDbContext>(sp => sp.GetRequiredService<RideSharingDbContext>());

            return services;
        }

        public static IServiceCollection AddRepository(this IServiceCollection services)
        {
            services.AddScoped<IRideRepository, RideRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IRideManagementService, RideManagementService>();

            services.AddTransient<RideBookingService>();

            return services;
        }
    }
}
