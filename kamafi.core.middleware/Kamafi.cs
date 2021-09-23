using System.Text.Json;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.FeatureManagement;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;

using kamafi.core.data;
using kamafi.core.services;

namespace kamafi.core.middleware
{
    public partial class MiddlewareExtensions
    {
        public static IServiceCollection AddKamafiServices<TDbContext>(
            this IServiceCollection services,
            IKamafiConfiguration config)
            where TDbContext : DbContext
        {
            return services.AddKamafiServices<TDbContext>(
                config.Config,
                config.OpenApiName,
                config.OpenApiVersion,
                config.DefaultApiVersion);
        }

        public static IServiceCollection AddKamafiServices<TDbContext>(
            this IServiceCollection services,
            IConfiguration config,
            string openApiName,
            string openApiVersion,
            string defaultApiVersion)
            where TDbContext : DbContext
        {
            services.AddScoped<IEnvConfiguration, EnvConfiguration>()
                .AddScoped<ITenant, Tenant>()
                .AddScoped<IEventRepository, EventRepository>();

            services.AddDbContext<TDbContext>(o => o.UseNpgsql(config[Keys.DataPostgreSQL], o => o.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery)));

            services.AddHealthChecks();
            services.AddFeatureManagement();
            services.AddLogging()
                .AddHttpContextAccessor()
                .AddApplicationInsightsTelemetry()
                .AddKamafiAuthentication(config)
                .AddKamafiSwaggerGen(config, openApiName, openApiVersion)
                .AddKamafiApiVersioning(defaultApiVersion)
                .AddEventingRestClient(config);

            services.AddControllers()
                .AddJsonOptions(o =>
                {
                    o.JsonSerializerOptions.WriteIndented = true;
                    o.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
                });

            return services;
        }

        public static IApplicationBuilder UseKamafiServices(
            this IApplicationBuilder builder,
            IConfiguration config,
            IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                builder.UseCors(x => x.WithOrigins(config[Keys.CorsPortal]).AllowAnyHeader().AllowAnyMethod());
            }

            builder.UseKamafiExceptionMiddleware();
            builder.UseKamafiUnauthorizedMiddleware();
            builder.UseHealthChecks("/health");
            builder.UseSwagger();

            builder.UseRouting();
            builder.UseAuthentication();
            builder.UseAuthorization();
            builder.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            return builder;
        }
    }
}
