using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.DependencyInjection;

namespace kamafi.core.middleware
{
    public static partial class MiddlewareExtensions
    {
        public static IServiceCollection AddKamafiApiVersioning(
            this IServiceCollection services,
            string defaultApiVersion)
        {
            services.AddApiVersioning(x =>
            {
                x.DefaultApiVersion = ApiVersion.Parse(defaultApiVersion);
                x.ReportApiVersions = true;
                x.ApiVersionReader = new UrlSegmentApiVersionReader();
                x.ErrorResponses = new ApiVersioningErrorResponseProvider();
            });

            return services;
        }
    }
}
