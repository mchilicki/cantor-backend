using Chilicki.Cantor.Infrastructure.Databases;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;

namespace Chilicki.Cantor.CurrencyUpdater.Configurations.DependencyInjection
{
    public class CurrencyUpdaterDIConfiguration
    {
        public IServiceProvider CreateServiceProvider()
        {
            var connectionString = "data source=localhost;initial catalog=CantorDevelopment;integrated security=True;MultipleActiveResultSets=True;";
            var serviceProvider = new ServiceCollection()
                .RegisterAllDependencies()
                .AddDbContext<DbContext, CantorDatabaseContext>(options =>
                options.UseSqlServer(
                    connectionString,
                    b => b.MigrationsAssembly(typeof(CantorDatabaseContext).Assembly.GetName().Name
                    ))
                )
               .BuildServiceProvider();
            return serviceProvider;
        }
    }
}
