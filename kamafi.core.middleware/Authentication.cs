using System.Security.Cryptography;

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

using kamafi.core.data;

namespace kamafi.core.middleware
{
    public static partial class MiddlewareExtensions
    {
        public static IServiceCollection AddKamafiAuthentication(
            this IServiceCollection services,
            string publicKey,
            string issuer,
            string audience)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(
                Keys.Bearer,
                x =>
                {
                    var rsa = RSA.Create();
                    rsa.FromXmlString(publicKey);

                    x.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidIssuer = issuer,
                        ValidateAudience = true,
                        ValidAudience = audience,
                        ValidateIssuerSigningKey = true,
                        ValidateLifetime = true,
                        IssuerSigningKey = new RsaSecurityKey(rsa)
                    };
                });

            return services;
        }

        public static IServiceCollection AddKamafiAuthentication(
            this IServiceCollection services,
            IConfiguration config)
        {
            return services.AddKamafiAuthentication(
                config[Keys.JwtPublicKey],
                config[Keys.JwtIssuer],
                config[Keys.JwtAudience]);
        }
    }
}
