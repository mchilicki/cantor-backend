using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Chilicki.Cantor.CurrencyUpdater.Configurations.DependencyInjection
{
    public class CurrencyUpdaterDIConfiguration
    {
        readonly AutomapperConfiguration automapperConfiguration;

        public CurrencyUpdaterDIConfiguration()
        {
            automapperConfiguration = new AutomapperConfiguration();
        }

        public IServiceProvider CreateServiceProvider(IConfigurationRoot configuration)
        {
            var services = new ServiceCollection()
                .RegisterAllDependencies(configuration);
            automapperConfiguration.ConfigureAutomapper(services);
            return services.BuildServiceProvider();
        }
    }
}
