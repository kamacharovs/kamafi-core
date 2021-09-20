using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Security.Claims;

using Microsoft.AspNetCore.Http;

namespace kamafi.core.data
{
    public class Tenant
    {
        [JsonPropertyName("user_id")]
        public int? UserId { get; set; }

        [JsonPropertyName("client_id")]
        public int? ClientId { get; set; }

        [JsonPropertyName("public_key")]
        public Guid? PublicKey { get; set; }

        [JsonIgnore]
        public string Log
        {
            get
            {
                return JsonSerializer.Serialize(this);
            }
        }

        public Tenant(IHttpContextAccessor httpContextAccessor)
        {
            Set(httpContextAccessor.HttpContext?.User);
        }
        public Tenant(HttpContext httpContext)
        {
            Set(httpContext?.User);
        }

        public void Set(ClaimsPrincipal user)
        {
            int userId, clientId;
            Guid publicKey;

            int.TryParse(user?.FindFirst(Keys.Claim.UserId)?.Value, out userId);
            int.TryParse(user?.FindFirst(Keys.Claim.ClientId)?.Value, out clientId);
            Guid.TryParse(user?.FindFirst(Keys.Claim.PublicKey)?.Value, out publicKey);

            UserId = userId;
            ClientId = clientId;
            PublicKey = publicKey;
        }
    }
}
