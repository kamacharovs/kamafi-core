using Microsoft.AspNetCore.Builder;

namespace kamafi.core.middleware
{
    public static partial class MiddlewareExtensions
    {
        public static IApplicationBuilder UseKamafiExceptionMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<KamafiExceptionMiddleware>();
        }

        public static IApplicationBuilder UseKamafiUnauthorizedMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<KamafiUnauthorizedMiddleware>();
        }
    }
}
