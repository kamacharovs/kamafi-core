using System.Text.Json;

using Microsoft.AspNetCore.Http;

namespace kamafi.core.data
{
    /// <summary>
    /// Constant values
    /// </summary>
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

    /// <summary>
    /// Constant keys
    /// </summary>
    public static class Keys
    {
        public const string Eventing = nameof(Eventing);
        public const string BaseUrl = nameof(BaseUrl);
        public const string FunctionKeyHeaderName = nameof(FunctionKeyHeaderName);
        public const string FunctionKey = nameof(FunctionKey);
        public const string EventingBaseUrl = nameof(Eventing) + ":" + nameof(BaseUrl);
        public const string EventingFunctionKeyHeaderName = nameof(Eventing) + ":" + nameof(FunctionKeyHeaderName);
        public const string EventingFunctionKey = nameof(Eventing) + ":" + nameof(FunctionKey);

        public const string Jwt = nameof(Jwt);
        public const string Bearer = nameof(Bearer);
        public const string Issuer = nameof(Issuer);
        public const string Audience = nameof(Audience);
        public const string PublicKey = nameof(PublicKey);
        public const string JwtIssuer = nameof(Jwt) + ":" + nameof(Issuer);
        public const string JwtAudience = nameof(Jwt) + ":" + nameof(Audience);
        public const string JwtPublicKey = nameof(Jwt) + ":" + nameof(PublicKey);

        public const string OpenApi = nameof(OpenApi);
        public const string Version = nameof(Version);
        public const string Title = nameof(Title);
        public const string Description = nameof(Description);
        public const string Contact = nameof(Contact);
        public const string Name = nameof(Name);
        public const string Email = nameof(Email);
        public const string Url = nameof(Url);
        public const string License = nameof(License);
        public const string OpenApiTitle = nameof(OpenApi) + ":" + nameof(Title);
        public const string OpenApiDescription = nameof(OpenApi) + ":" + nameof(Description);
        public const string OpenApiContactName = nameof(OpenApi) + ":" + nameof(Contact) + ":" + nameof(Name);
        public const string OpenApiContactEmail = nameof(OpenApi) + ":" + nameof(Contact) + ":" + nameof(Email);
        public const string OpenApiContactUrl = nameof(OpenApi) + ":" + nameof(Contact) + ":" + nameof(Url);
        public const string OpenApiLicenseName = nameof(OpenApi) + ":" + nameof(License) + ":" + nameof(Name);
        public const string OpenApiLicenseUrl = nameof(OpenApi) + ":" + nameof(License) + ":" + nameof(Url);

        public static class Claim
        {
            public const string UserId = "user_id";
            public const string ClientId = "client_id";
            public const string PublicKey = "public_key";
        }
    }
}
