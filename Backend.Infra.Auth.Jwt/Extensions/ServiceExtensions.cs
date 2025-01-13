using System.Text;
using Backend.Core.Domain.Interfaces;
using Backend.Infra.Auth.Jwt.Configurations;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace Backend.Infra.Auth.Jwt.Extensions;

public static class ServiceExtensions
{
    public static void ConfigureAuthApp(this IServiceCollection services)
    {
        var issuer = Environment.GetEnvironmentVariable("JWT_ISSUER")
            ?? throw new Exception("JWT_ISSUER environment variable missing.");
        var audience = Environment.GetEnvironmentVariable("JWT_AUDIENCE")
            ?? throw new Exception("JWT_AUDIENCE environment variable missing.");
        var secretKey = Environment.GetEnvironmentVariable("JWT_SECRET_KEY")
            ?? throw new Exception("JWT_SECRET_KEY environment variable missing.");

        services.Configure<JwtSettings>(x =>
        {
            x.Issuer = issuer;
            x.Audience = audience;
            x.SecretKey = secretKey;
        });

        services.AddAuthentication(options =>
        {
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        })
        .AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                RequireSignedTokens = true,
                ValidIssuer = issuer,
                ValidAudience = audience,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey)),
                ClockSkew = TimeSpan.Zero,
            };
        });

        services.AddTransient<IJwtTokenGenerator, JwtTokenGenerator>();
    }
}
