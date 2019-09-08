using Microsoft.Extensions.Configuration;
using System;

namespace Chilicki.Cantor.CurrencyUpdater.Configurations.HostConfigurations
{
    public class ApplicationConfiguration
    {
        public IConfigurationRoot Configure()
        {
            var environmentName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            var builder = new ConfigurationBuilder()
                .AddJsonFile($"appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{environmentName}.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables();
            var configuration = builder.Build();            
            return configuration;
        }
    }
}
