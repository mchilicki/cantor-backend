using Chilicki.Cantor.Domain.Entities.Base;
using Chilicki.Cantor.Infrastructure.Databases;
using Chilicki.Cantor.Infrastructure.Repositories.Base;
using Chilicki.Cantor.Infrastructure.Repositories.Cantors;
using Chilicki.Cantor.Infrastructure.Repositories.Cantors.Base;
using Chilicki.Cantor.Infrastructure.Repositories.Currencies;
using Chilicki.Cantor.Infrastructure.Repositories.Currencies.Base;
using Chilicki.Cantor.Infrastructure.Repositories.Users;
using Chilicki.Cantor.Infrastructure.Repositories.Users.Base;
using Chilicki.Cantor.Infrastructure.Repositories.Wallets;
using Chilicki.Cantor.Infrastructure.Repositories.Wallets.Base;
using Chilicki.Cantor.Infrastructure.RestClients;
using Chilicki.Cantor.Infrastructure.RestClients.Base;
using Chilicki.Cantor.Infrastructure.UnitsOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Hosting.Internal;
using System;
using System.Collections.Generic;

namespace Chilicki.Cantor
{
    public static class InfrastructureDIConfiguration
    {
        public static void RegisterInfrastructureDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.RegisterRepositories();
            services.RegisterBaseRepositories();
            services.RegisterRestClients();
            services.RegisterDatabase(configuration);
        }

        private static void RegisterRepositories(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ICantorCurrencyRepository, CantorCurrencyRepository>();
            services.AddScoped<ICantorWalletRepository, CantorWalletRepository>();
            services.AddScoped<ICurrencyRepository, CurrencyRepository>();
            services.AddScoped<IWalletCurrencyRepository, WalletCurrencyRepository>();
        }

        private static void RegisterBaseRepositories(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IBaseRepository<BaseEntity>, BaseRepository<BaseEntity>>();
        }

        private static void RegisterRestClients(this IServiceCollection services)
        {
            services.AddScoped<ICurrencyUpdaterRestClient, CurrencyUpdaterRestClient>();
        }

        private static void RegisterDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            var databaseConnectionString = configuration.GetConnectionString("Cantor");
            services.AddDbContext<DbContext, CantorDatabaseContext>(options => options
                .UseSqlServer(
                    databaseConnectionString,
                    b => b.MigrationsAssembly(typeof(CantorDatabaseContext).Assembly.GetName().Name
                ))
                .UseLazyLoadingProxies()
            );
        }
    }
}
