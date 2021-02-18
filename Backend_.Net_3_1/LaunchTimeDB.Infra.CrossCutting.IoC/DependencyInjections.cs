using LaunchTimeDB.Application.AppInterfaces;
using LaunchTimeDB.Application.AppServices;
using LaunchTimeDB.DataStore.FakeData;
using LaunchTimeDB.Domain.Interfaces.Repositories;
using LaunchTimeDB.Domain.Interfaces.Services;
using LaunchTimeDB.Domain.Services.Services;
using Microsoft.Extensions.DependencyInjection;

namespace LaunchTimeDB.Infra.CrossCutting.IoC
{
    public static class DependencyInjections
    {
        public static void AddDependencyInjections(this IServiceCollection services)
        {
            AddScopedRepositories(services);
            AddScopedServices(services);
            AddScopedAppServices(services);
        }

        private static void AddScopedRepositories(IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IRestaurantRepository, RestaurantRepository>();
            services.AddScoped<IFacilitatorRepository, FacilitatorRepository>();
        }

        private static void AddScopedServices(IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IRestaurantService, RestaurantService>();
            services.AddScoped<IFacilitatorService, FacilitatorService>();
        }

        private static void AddScopedAppServices(IServiceCollection services)
        {
            services.AddScoped<IUserAppService, UserAppService>();
            services.AddScoped<IRestaurantAppService, RestaurantAppService>();
            services.AddScoped<IFacilitatorAppService, FacilitatorAppService>();
        }
    }
}
