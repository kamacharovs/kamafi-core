using System;
using System.IO;
using System.Reflection;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.OpenApi.Models;

using kamafi.core.data;

namespace kamafi.core.middleware
{
    public static partial class MiddlewareExtensions
    {
        public static IServiceCollection AddKamafiSwaggerGen(
            this IServiceCollection services,
            OpenApiGeneral general,
            OpenApiContact contact,
            OpenApiLicense license)
        {
            services.AddSwaggerGen(x =>
            {
                x.SwaggerDoc(general.Name, new OpenApiInfo
                {
                    Title = general.Title,
                    Version = general.Version,
                    Description = general.Description,
                    Contact = contact,
                    License = license
                });

                //x.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, $"{Assembly.GetExecutingAssembly().GetName().Name}.xml"));
            });

            return services;
        }

        public static IServiceCollection AddKamafiSwaggerGen(
            this IServiceCollection services,
            IConfiguration config,
            string name,
            string version)
        {
            return services.AddKamafiSwaggerGen(
                new OpenApiGeneral
                {
                    Name = name,
                    Title = config[Keys.OpenApiTitle],
                    Version = version,
                    Description = config[Keys.OpenApiDescription]
                },
                new OpenApiContact
                {
                    Name = config[Keys.OpenApiContactName],
                    Email = config[Keys.OpenApiContactEmail],
                    Url = new Uri(config[Keys.OpenApiContactUrl])
                },
                new OpenApiLicense
                {
                    Name = config[Keys.OpenApiLicenseName],
                    Url = new Uri(config[Keys.OpenApiLicenseUrl])
                });
        }
    }
}
