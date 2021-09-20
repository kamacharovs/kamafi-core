using System.Text.Json;

using Microsoft.AspNetCore.Http;

namespace kamafi.core.data
{
    public static class Constants
    {
        public const string Accept = nameof(Accept);
        public const string ApplicationJson = "application/json";
        public const string ApplicationProblemJson = "application/problem+json";

        public const string DefaultMessage = "An unexpected error has occurred";
        public const string DefaultValidationMessage = "One or more validation errors have occurred. Please see errors for details";
        public const string DefaultUnauthorizedMessage = "Unauthorized. Missing, invalid or expired credentials provided";
        public const string DefaultForbiddenMessage = "Forbidden. You don't have enough permissions to access this API";
        public const string DefaultUnsupportedApiVersionMessage = "Unsupported API version specified";

        public static JsonSerializerOptions JsonSerializerSettings
            => new JsonSerializerOptions
            {
                WriteIndented = true,
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                IgnoreNullValues = true
            };

        public static int[] AllowedUnauthorizedStatusCodes
            => new int[]
            {
                StatusCodes.Status401Unauthorized,
                StatusCodes.Status403Forbidden
            };
    }

    public static class Keys
    {
        public const string Bearer = nameof(Bearer);

        public static class Claim
        {
            public const string UserId = "user_id";
            public const string ClientId = "client_id";
            public const string PublicKey = "public_key";
        }
    }
}
