using challenge.application.layer.api;
using challenge.application.layer.api.Services.Calendars;
using challenge.application.layer.api.Services.users;
using challenge.application.layer.api.Services.Users;
using challenge.application.layer.Services.Security;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("challenge.bootstrapper.layer")]
namespace challenge.presentation.layer.api
{
    internal static class PresentationModule
    {
        public static IServiceCollection AddPresentationModule(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ICalendarServices, CalendarService>();
            services.AddScoped<ISecurityServices, SecurityServices>();
            services.AddApplicationModule(configuration);

            return services;
        }
        public static IApplicationBuilder UsePresentationModule(this IApplicationBuilder app, IConfiguration configuration)
        {
            app.UseApplicationModule(configuration);
            return app;
        }

    }
}
