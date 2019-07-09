using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chilicki.Cantor.Application.Commands.Auth;
using Chilicki.Cantor.Application.CommandHandlers.Auth;
using Chilicki.Cantor.Infrastructure.Databases;
using Chilicki.Cantor.WebAPI.Configurations;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Chilicki.Cantor.Application.DTOs;
using Chilicki.Cantor.Infrastructure.UnitsOfWork;
using Chilicki.Cantor.Infrastructure.Repositories.Base;
using Chilicki.Cantor.Domain.Entities.Base;
using Chilicki.Cantor.Infrastructure.Repositories.Users.Base;
using Chilicki.Cantor.Infrastructure.Repositories.Users;
using AutoMapper;

namespace Chilicki.Cantor.WebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            ConfigureMVC(services);
            ConfigureMediatR(services);
            ConfigureDatabase(services);
            ConfigureJWTAuthentication(services);
            ConfigureAutomapper(services);
            RegisterDependencies(services);
        }        

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseMvc();
        }

        private static void ConfigureMVC(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        private static void ConfigureMediatR(IServiceCollection services)
        {
            services.AddMediatR(assemblies: typeof(Startup).Assembly);
        }

        private void ConfigureDatabase(IServiceCollection services)
        {
            var connectionString = Configuration.GetConnectionString("CantorDevelopment");
            services.AddDbContext<CantorDatabaseContext>(options =>
                options.UseSqlServer(connectionString, b => b.MigrationsAssembly("Chilicki.Cantor.Infrastructure"))
            );
        }

        private void ConfigureJWTAuthentication(IServiceCollection services)
        {
            var appSettingsSection = Configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettingsSection);
            var appSettings = appSettingsSection.Get<AppSettings>();
            var key = Encoding.ASCII.GetBytes(appSettings.Secret);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });
        }

        private void ConfigureAutomapper(IServiceCollection services)
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new AutomapperProfile());
            });
            var mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
        }

        private void RegisterDependencies(IServiceCollection services)
        {
            RegisterInfrastructureDependencies(services);
            RegisterApplicationDependencies(services);
        }        

        private void RegisterInfrastructureDependencies(IServiceCollection services)
        {
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IBaseRepository<BaseEntity>, BaseRepository<BaseEntity>>();
            services.AddTransient<IUserRepository, UserRepository>();
        }

        private void RegisterApplicationDependencies(IServiceCollection services)
        {
            services.AddTransient<IRequestHandler<AuthenticateUserCommand, string>, AuthenticateUserHandler>();
            services.AddTransient<IRequestHandler<RegisterUserCommand, UserDTO>, RegisterUserHandler>();
        }
    }
}
