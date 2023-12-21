using Microsoft.Extensions.DependencyInjection;
using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using challenge.application.layer.Services.Events;

[assembly: InternalsVisibleTo("challenge.presentation.layer")]
namespace challenge.application.layer
{
    public static class ApplicationModule
    {
        public static IServiceCollection AddApplicationModule(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IEventService, EventService>();

            return services;
        }
        public static IApplicationBuilder UseApplicationModule(this IApplicationBuilder app, IConfiguration configuration)
        {
            return app;
        }

    }
}
