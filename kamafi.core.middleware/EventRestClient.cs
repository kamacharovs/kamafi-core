using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using RestSharp;

using kamafi.core.data;

namespace kamafi.core.middleware
{
    public static partial class MiddlewareExtensions
    {
        /// <summary>
        /// Configuration values that are used.
        /// Uses
        /// <see cref="Keys.EventingBaseUrl"/>.
        /// Uses (optional)
        /// <see cref="Keys.EventingFunctionKeyHeaderName"/>
        /// <see cref="Keys.EventingFunctionKey"/>.
        /// </summary>
        /// <param name="services"></param>
        /// <param name="config"></param>
        /// <param name="useFunctionDefaultHeader">Flag whether to use the Azure Function default header (header name and key). Defaults to true</param>
        /// <returns></returns>
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
