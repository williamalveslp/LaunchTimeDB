using LaunchTimeDB.API.ServicesCollections;
using LaunchTimeDB.Infra.CrossCutting;
using LaunchTimeDB.Infra.CrossCutting.IoC;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace LaunchTimeDB.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers()
                 .AddJsonOptions(options => options.JsonSerializerOptions.WriteIndented = true);

            // Cors.
            services.AddCorsSettings(Configuration);

            // Dependency Injections.
            services.AddDependencyInjections();

            // Swagger Documentations.
            services.AddSwagger(Configuration);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseRouting();

            AppCors(app);

            // Are you allowed?  
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            AppSwagger(app);
        }

        /// <summary>
        /// Activating Swagger middlewares.
        /// </summary>
        /// <param name="app"></param>
        private void AppSwagger(IApplicationBuilder app)
        {
            var swaggerData = ConfigurationTransfer.GetObject<SwaggerSettings>(Configuration);
            app.UseSwagger();
            app.UseSwaggerUI(op => op.SwaggerEndpoint($"/swagger/{swaggerData?.Version}/swagger.json", swaggerData?.Title));
        }

        /// <summary>
        /// Activing Cors middlewares.
        /// </summary>
        /// <param name="app"></param>
        private void AppCors(IApplicationBuilder app)
        {
            var corsData = ConfigurationTransfer.GetObject<CorsSettings>(Configuration);
            app.UseCors(corsData.Key);
        }
    }
}
