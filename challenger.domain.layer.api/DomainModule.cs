using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("challenge.bootstrapper.layer")]
namespace challenge.presentation.layer
{
    internal static class DomainModule
    {
        public static IServiceCollection AddDomainModule(this IServiceCollection services, IConfiguration configuration)
        {
            return services;
        }
        public static IApplicationBuilder UseDomainModule(this IApplicationBuilder app, IConfiguration configuration)
        {
            return app;
        }

    }
}
