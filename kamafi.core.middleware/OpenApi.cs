using System;
using System.IO;
using System.Reflection;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace kamafi.core.middleware
{
    public static partial class MiddlewareExtensions
    {
        public static IServiceCollection AddKamafiSwaggerGen(
            this IServiceCollection services,
            string name,
            string title,
            string version,
            string description,
            OpenApiContact contact,
            OpenApiLicense license)
        {
            services.AddSwaggerGen(x =>
            {
                x.SwaggerDoc(name, new OpenApiInfo
                {
                    Title = title,
                    Version = version,
                    Description = description,
                    Contact = contact,
                    License = license
                });
                x.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, $"{Assembly.GetExecutingAssembly().GetName().Name}.xml"));
            });

            return services;
        }
    }
}
