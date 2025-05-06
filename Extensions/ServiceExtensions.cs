using System.Text;
using FinSystem.Models;
using FinSystem.Providers;
using FinSystem.Repository;
using FinSystem.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace FinSystem.Extensions;

public static class ServiceExtensions
{
    public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<JwtOptions>(configuration.GetSection("JwtOptions"));
        
        var jwtOptns = configuration.GetSection("JwtOptions").Get<JwtOptions>();
        services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = jwtOptns.Issuer,
                    ValidAudience = jwtOptns.Audience,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOptns.SecretKey))
                };
            });
        
        services.AddControllers();
        services.AddEndpointsApiExplorer();         // Need for analyse endpoints
        services.AddSwaggerGen(options =>
        {
            var xmlFIleName = $"{typeof(ServiceExtensions).Assembly.GetName().Name}.xml";
            options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFIleName));
        });                   // Genarates Swagger JSON and UI
        services.AddCors(options =>
        {
            options.AddPolicy("Frontend", policy =>
            {
                policy.WithOrigins("http://myfrontend.com")
                    .AllowAnyHeader()
                    .AllowAnyMethod();
            });
        });

        services.AddScoped<PasswordHasher>();
        services.AddScoped<JwtProvider>();

        services.AddScoped<UserRepository>();
        services.AddScoped<UserService>();

        return services;
    }
}
