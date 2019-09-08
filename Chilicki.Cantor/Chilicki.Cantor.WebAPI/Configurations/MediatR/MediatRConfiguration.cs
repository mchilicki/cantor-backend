using Chilicki.Cantor.WebAPI;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Chilicki.Cantor
{
    public class MediatRConfiguration
    {
        public void Configure(IServiceCollection services)
        {
            services.AddMediatR(assemblies: typeof(Startup).Assembly);
        }
    }
}
