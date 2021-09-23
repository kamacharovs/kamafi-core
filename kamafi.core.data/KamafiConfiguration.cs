using System;

using Microsoft.Extensions.Configuration;

namespace kamafi.core.data
{
    /// <summary>
    /// Servces as the main configuration surrounding services
    /// </summary>
    public class KamafiConfiguration : IKamafiConfiguration
    {
        public IConfiguration Config { get; set; }
        public string OpenApiName { get; set; }
        public string OpenApiVersion { get; set; }
        public string DefaultApiVersion { get; set; }

        public KamafiConfiguration()
        {

        }
    }
}
