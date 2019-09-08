using Chilicki.Cantor.Infrastructure.Databases;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;

namespace Chilicki.Cantor.CurrencyUpdater.Configurations.DependencyInjection
{
    public class CurrencyUpdaterDIConfiguration
    {
        public IServiceProvider CreateServiceProvider(IConfigurationRoot configuration)
        {
            var environmentName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            var databaseConnectionString = configuration.GetConnectionString(environmentName);
            var serviceProvider = new ServiceCollection()
                .RegisterAllDependencies(databaseConnectionString)
               .BuildServiceProvider();
            return serviceProvider;
        }
    }
}
