using System.Threading.Tasks;

namespace kamafi.core.data
{
    /// <summary>
    /// Serves as an environment configuration logic. For example, checking if a feature flag is enabled
    /// </summary>
    public interface IEnvConfiguration
    {
        Task<bool> IsEnabledAsync(string featureFlag);
        Task<bool> IsEnabledAsync(FeatureFlags featureFlag);
    }
}
