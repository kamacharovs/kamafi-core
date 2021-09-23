using System;
using System.Text.Json.Serialization;

namespace kamafi.core.data
{
    /// <summary>
    /// Serves to capture details on an authenticated user. 
    /// It investigates the <see cref="System.Security.Claims.ClaimsPrincipal"/> and reads the claims into this object.
    /// The claims are stored as a JWT and passed down the ecosystem
    /// </summary>
    public interface ITenant
    {
        [JsonPropertyName("user_id")]
        int? UserId { get; set; }

        [JsonPropertyName("client_id")]
        int? ClientId { get; set; }

        [JsonPropertyName("public_key")]
        Guid? PublicKey { get; set; }

        [JsonIgnore]
        string Log { get; }
    }
}
