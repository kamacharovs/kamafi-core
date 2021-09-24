using System;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using kamafi.core.data;
using kamafi.core.middleware;

namespace kamafi.core.middleware.tests
{
    public class Startup
    {
        public readonly IConfiguration _config;
        public readonly IWebHostEnvironment _env;

        public Startup(
            IConfiguration config,
            IWebHostEnvironment env)
        {
            _config = config ?? throw new ArgumentNullException(nameof(config));
            _env = env ?? throw new ArgumentNullException(nameof(env));
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddKamafiServices<DataContext>(
                _config,
                Constants.ApiName,
                Constants.ApiV1Full,
                Constants.ApiV1);
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseKamafiServices(_config, _env);
        }
    }
}
