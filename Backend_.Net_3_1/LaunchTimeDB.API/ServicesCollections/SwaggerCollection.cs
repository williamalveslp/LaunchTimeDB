using LaunchTimeDB.Infra.CrossCutting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.IO;
using System.Reflection;

namespace LaunchTimeDB.API.ServicesCollections
{
    internal static class SwaggerCollection
    {
        public static void ConfigureSwagger(this IServiceCollection services, IConfiguration configuration)
        {
            var swaggerData = ConfigurationTransfer.GetObject<SwaggerSettings>(configuration);

            _ = services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc(swaggerData.Version,
                    new OpenApiInfo
                    {
                        Title = swaggerData.Title,
                        Version = swaggerData.Version,
                        Description = swaggerData?.Description,
                        Contact = new OpenApiContact
                        {
                            Name = swaggerData?.Contact?.Name,
                            Email = swaggerData?.Contact?.Email,
                            Url = new Uri(swaggerData?.Contact?.Url)
                        }
                    });

                // Set the comments path for the Swagger JSON and UI (Properties > Build > set 'XML documentation file').
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });
        }
    }

    internal class SwaggerSettings
    {
        public string Title { get; set; }
        public string Version { get; set; }
        public string Description { get; set; }
        public ContactDto Contact { get; set; }

        internal class ContactDto
        {
            public string Name { get; set; }
            public string Email { get; set; }
            public string Url { get; set; }
        }
    }
}
