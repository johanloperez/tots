using challenge.application.layer;
using challenge.application.layer.Services.users;
using challenge.application.layer.Services.Users;
using challenge.application.layer.Services.Security;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Runtime.CompilerServices;
using challenge.application.layer.UseCases.Events;

[assembly: InternalsVisibleTo("challenge.bootstrapper.layer")]
namespace challenge.presentation.layer
{
    internal static class PresentationModule
    {
        public static IServiceCollection AddPresentationModule(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IGetEvents, GetEvents>();
            services.AddScoped<ICreateEvents, CreateEvents>();
            services.AddScoped<IEditEvents, EditEvents>();
            services.AddScoped<IDeleteEvents, DeleteEvents>();
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
