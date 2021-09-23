using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using RestSharp;

using kamafi.core.data;

namespace kamafi.core.middleware
{
    public static partial class MiddlewareExtensions
    {
        public static IServiceCollection AddEventingRestClient(
            this IServiceCollection services,
            IConfiguration config,
            bool useFunctionDefaultHeader = true)
        {
            services.AddSingleton<IRestClient>(x =>
            {
                var client = new RestClient(config[Keys.EventingBaseUrl]);

                if (useFunctionDefaultHeader)
                {
                    client.AddDefaultHeader(config[Keys.EventingFunctionKeyHeaderName], config[Keys.EventingFunctionKey]);
                }

                return client;
            });

            return services;
        }
    }
}
