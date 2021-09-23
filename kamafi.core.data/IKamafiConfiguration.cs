using Microsoft.Extensions.Configuration;

namespace kamafi.core.data
{
    /// <summary>
    /// Servces as the main configuration surrounding services
    /// </summary>
    public interface IKamafiConfiguration
    {
        IConfiguration Config { get; set; }
        string DefaultApiVersion { get; set; }
        string OpenApiName { get; set; }
        string OpenApiVersion { get; set; }
    }
}