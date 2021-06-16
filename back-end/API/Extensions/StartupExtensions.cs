using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Services;
using Services.Interfaces;
using Strijp_T_Hotspots.Configurations;
using Strijp_T_Hotspots.Configurations.Automapper;
using System;
using System.Text;

namespace Strijp_T_Hotspots.Extensions
{
    public static class StartupExtensions
    {
        public static void ConfigureAuthenticationHandler(this IServiceCollection services)
        {
            services.AddScoped<IAuthenticationHandler, AuthenticationHandler>();
        }

        public static void ConfigurePasswordManager(this IServiceCollection services)
        {
            services.AddScoped<IEncoder, Services.Encoder>();
        }

        public static void ConfigureJWTHandler(this IServiceCollection services)
        {
            services.AddScoped<IJWTHandler, JWTHandler>();
        }

        public static void ConfigureAutoMapper(this IServiceCollection services)
        {
            MapperConfiguration mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });
            try
            {
                mappingConfig.AssertConfigurationIsValid();

            } catch(Exception e)
            {
                Console.WriteLine(e);
            }

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
        }

        public static void ConfigureAuthentication(this IServiceCollection services, Config config)
        {
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config.Jwt.Key)),
                    ValidateIssuerSigningKey = true

                };
            });
        }
        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsDevelopment", builder =>
                {
                    builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
                });
            });
        }

    }
}
