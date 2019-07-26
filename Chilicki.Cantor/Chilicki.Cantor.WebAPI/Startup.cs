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
using Chilicki.Cantor.Domain.Factories.Users.Base;
using Chilicki.Cantor.Domain.Factories.Users;
using Chilicki.Cantor.Domain.ValueObjects.Users;
using Chilicki.Cantor.Domain.Services.Users;
using Chilicki.Cantor.Domain.Services.Users.Base;
using Chilicki.Cantor.Application.Configurations.Auth;
using Chilicki.Cantor.Domain.Services.Auth.Base;
using Chilicki.Cantor.Domain.Services.Auth;
using Chilicki.Cantor.WebAPI.Configurations.Automapper;
using Chilicki.Cantor.Infrastructure.Repositories.Cantors;
using Chilicki.Cantor.Infrastructure.Repositories.Cantors.Base;
using Chilicki.Cantor.Infrastructure.Repositories.Currencies.Base;
using Chilicki.Cantor.Infrastructure.Repositories.Currencies;
using Chilicki.Cantor.Infrastructure.Repositories.Wallets;
using Chilicki.Cantor.Infrastructure.Repositories.Wallets.Base;
using Microsoft.AspNetCore.Http;
using Chilicki.Cantor.WebAPI.Controllers.Base;
using Chilicki.Cantor.Application.CommandHandlers.Charges;
using Chilicki.Cantor.Application.Commands.Charges;
using Chilicki.Cantor.Domain.Services.Charges;
using Chilicki.Cantor.Domain.Services.Charges.Base;
using Chilicki.Cantor.Application.Queries;
using Chilicki.Cantor.Application.QueryHandlers;
using Chilicki.Cantor.Application.DTOs.Currencies;
using Chilicki.Cantor.Application.Helpers.Users;
using Chilicki.Cantor.Application.Helpers.Users.Base;

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
            app.UseMiddleware(typeof(ErrorMiddlewareHandler));
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
            services.AddDbContext<DbContext, CantorDatabaseContext>(options =>
                options.UseSqlServer(
                    connectionString, 
                    b => b.MigrationsAssembly(typeof(CantorDatabaseContext).Assembly.GetName().Name
                ))
            );
        }

        private void ConfigureJWTAuthentication(IServiceCollection services)
        {
            var authenticationSettingsSection = Configuration.GetSection(nameof(AuthenticationSettings));
            services.Configure<AuthenticationSettings>(authenticationSettingsSection);
            var authenticationSettings = authenticationSettingsSection.Get<AuthenticationSettings>();
            var key = Encoding.ASCII.GetBytes(authenticationSettings.Secret);
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
            RegisterDomainDependencies(services);
            RegisterApplicationDependencies(services);
        }        

        private void RegisterInfrastructureDependencies(IServiceCollection services)
        {
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IBaseRepository<BaseEntity>, BaseRepository<BaseEntity>>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<ICantorCurrencyRepository, CantorCurrencyRepository>();
            services.AddTransient<ICantorWalletRepository, CantorWalletRepository>();
            services.AddTransient<ICurrencyRepository, CurrencyRepository>();
            services.AddTransient<IWalletCurrencyRepository, WalletCurrencyRepository>();
        }

        private void RegisterDomainDependencies(IServiceCollection services)
        {
            services.AddTransient<IUserFactory, UserFactory>();
            services.AddTransient<IUserTokenFactory, UserTokenFactory>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IUserTokenGenerator, UserTokenGenerator>();
            services.AddTransient<IChargeAccountService, ChargeAccountService>();
        }

        private void RegisterApplicationDependencies(IServiceCollection services)
        {
            services.AddTransient<IRequestHandler<AuthenticateUserCommand, UserToken>, AuthenticateUserHandler>();
            services.AddTransient<IRequestHandler<RegisterUserCommand, UserDto>, RegisterUserHandler>();
            services.AddTransient<IRequestHandler<ChargeAccountCommand, UserDto>, ChargeAccountHandler>();
            services.AddTransient<IRequestHandler<GetCantorCurrenciesQuery, IEnumerable<CantorCurrencyDto>>, GetCantorCurrenciesHandler>();
            services.AddTransient<IRequestHandler<GetUserCurrenciesQuery, IEnumerable<UserCurrencyDto>>, GetUserCurrenciesHandler>();
            services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();
            services.AddTransient<ICurrentUserService, CurrentUserService>();
        }
    }
}
