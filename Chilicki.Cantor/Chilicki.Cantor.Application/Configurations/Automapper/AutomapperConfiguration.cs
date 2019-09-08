using AutoMapper;
using Chilicki.Cantor.Application.Configurations.Automapper;
using Microsoft.Extensions.DependencyInjection;

namespace Chilicki.Cantor
{
    public class AutomapperConfiguration
    {
        public void ConfigureAutomapper(IServiceCollection services)
        {
            var container = services.BuildServiceProvider();
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.ConstructServicesUsing(type => container.GetRequiredService(type));
                mc.AddProfile(new AutomapperProfile());
            });
            var mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}
