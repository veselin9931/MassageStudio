using Common.Repositories;
using Data.Repositories;
using Data.Seeding;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Services;

namespace MassageStudio
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection RegisterCustomServices(this IServiceCollection services)
        {
            services.AddTransient<ISeeder, MassageTypesSeeder>();

            services.AddTransient<ICustumerService, CustumerService>();
            services.AddTransient<IMasseurService, MasseurService>();
            services.AddTransient<IMassageTypesService, MassageTypesService>();
            services.AddTransient<IReservationService, ReservationService>();

            services.AddSingleton<IHttpContextAccessor,
            HttpContextAccessor>();

            return services;
        }

        public static IServiceCollection RegisterRepositoryServices(this IServiceCollection services)
        {
            services.AddScoped(typeof(IDeletableEntityRepository<>), typeof(EfDeletableEntityRepository<>));
            services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));

            return services;
        }
    }
}
