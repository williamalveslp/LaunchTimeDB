using LaunchTimeDB.Infra.CrossCutting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LaunchTimeDB.API.ServicesCollections
{
    internal static class CorsCollection
    {
        /// <summary>
        /// Add Policies to Cors to accept requests from another specifics domains.
        /// It's a Access-Control-Allow-Origin.
        /// </summary>
        /// <param name="services"></param>
        public static void AddCorsSettings(this IServiceCollection services, IConfiguration configuration)
        {
            var corsData = ConfigurationTransfer.GetObject<CorsSettings>(configuration);

            services.AddCors(options =>
            {
                options.AddPolicy(name: corsData.Key, builder =>
                {
                    builder.WithOrigins(corsData.EndpointAllowed);
                });
            });
        }
    }

    internal class CorsSettings
    {
        public string Key { get; set; }

        public string EndpointAllowed { get; set; }
    }
}
