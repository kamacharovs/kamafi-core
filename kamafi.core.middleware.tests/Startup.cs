using System;
using System.IO;
using System.Reflection;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

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
            services.AddKamafiServices<DataContext>(new data.KamafiConfiguration()
            {
                Config = _config,
                OpenApiName = Constants.ApiName,
                OpenApiVersion = Constants.ApiV1Full,
                DefaultApiVersion = Constants.ApiV1,
                XmlCommentsPath = Path.Combine(AppContext.BaseDirectory, $"{Assembly.GetExecutingAssembly().GetName().Name}.xml")
            });
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseKamafiServices(_config, _env);
        }
    }
}
