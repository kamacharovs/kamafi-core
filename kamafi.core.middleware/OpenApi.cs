using System;
using System.IO;
using System.Reflection;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

using kamafi.core.data;

namespace kamafi.core.middleware
{
    public static partial class MiddlewareExtensions
    {
        //TODO add overloaded method to accept IConfiguration
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
                x.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, $"{Assembly.GetExecutingAssembly().GetName().Name}.xml"));
            });

            return services;
        }
    }
}
