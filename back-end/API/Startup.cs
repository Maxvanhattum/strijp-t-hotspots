using Data.Context;
using DataTransferObjects;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using Services.Interfaces;
using Strijp_T_Hotspots.Configurations;
using Strijp_T_Hotspots.Extensions;
using System;
using System.Collections.Generic;

namespace Strijp_T_Hotspots
{
    public class Startup
    {
        public Config Config { get; set; }
        public Startup(IConfiguration configuration)
        {
            Config = configuration.GetSection("App").Get<Config>();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<DBContextApp>(options =>
            {

                options.UseMySql($"server={Config.DatabaseConnection.Server};port={Config.DatabaseConnection.Port};database={Config.DatabaseConnection.Database};uid={Config.DatabaseConnection.User};password={Config.DatabaseConnection.Password}",

                    mySqlOptions =>
                    {
                        mySqlOptions.ServerVersion(new Version(5, 7, 17), ServerType.MySql)
                        .EnableRetryOnFailure(
                        maxRetryCount: 10,
                        maxRetryDelay: TimeSpan.FromSeconds(30),
                        errorNumbersToAdd: null);
                    });
            });
            services.ConfigureAuthentication(Config);
            services.ConfigureAutoMapper();
            services.ConfigureCors();
            services.AddSwaggerGen(c =>
           {
               c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
               {
                   Description = @"JWT Authorization header using the Bearer scheme. \r\n\r\n 
                      Enter 'Bearer' [space] and then your token in the text input below.
                      \r\n\r\nExample: 'Bearer 12345abcdef'",
                   Name = "Authorization",
                   In = ParameterLocation.Header,
                   Type = SecuritySchemeType.ApiKey,
                   Scheme = "Bearer"
               });

               c.AddSecurityRequirement(new OpenApiSecurityRequirement()
     {
        {
          new OpenApiSecurityScheme
          {
            Reference = new OpenApiReference
              {
                Type = ReferenceType.SecurityScheme,
                Id = "Bearer"
              },
              Scheme = "oauth2",
              Name = "Bearer",
              In = ParameterLocation.Header,

            },
            new List<string>()
          }
       });
           });
            services.AddControllers();
            services.AddServicesAndRepositories();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, DBContextApp dBContextApp, IAuthenticationHandler authenticationHandler, IDatabaseSeeder databaseSeeder)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            dBContextApp.Database.Migrate();

            try
            {
                authenticationHandler.CreateUser(new UserCreateRequestDTO("admin@strijp-t.nl", "admin", "Administrator", "Strijp-T", "ADMIN"));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            databaseSeeder.SeedHotspots();

            if (!Config.DockerProduction.NoSSL.Equals("true"))
            {
                app.UseHttpsRedirection();
            }


            app.UseRouting();

            if (Config.DockerProduction.ConfigureCors.Equals("true"))
            {
                app.UseCors(c =>
               {
                   c.WithOrigins(Config.DockerProduction.CorsUrl);
                   c.SetIsOriginAllowedToAllowWildcardSubdomains();
                   c.AllowAnyHeader();
                   c.AllowAnyMethod();
               });
            }
            else
            {
                app.UseCors("CorsDevelopment");
            }

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint(Config.DockerProduction.SwaggerPrefix + "/swagger/v1/swagger.json", "STRIJP-T REST API V1");

            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers().RequireCors("CorsDevelopment");
            });


        }
    }
}
