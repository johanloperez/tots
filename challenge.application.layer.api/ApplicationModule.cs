using Microsoft.Extensions.DependencyInjection;
using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;

[assembly: InternalsVisibleTo("challenge.presentation.layer")]
namespace challenge.application.layer.api
{
    public static class ApplicationModule
    {
        public static IServiceCollection AddApplicationModule(this IServiceCollection services, IConfiguration configuration)
        {
            return services;
        }
        public static IApplicationBuilder UseApplicationModule(this IApplicationBuilder app, IConfiguration configuration)
        {
            return app;
        }

    }
}
