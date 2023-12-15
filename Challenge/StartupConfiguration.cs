using challenge.application.layer.api.Services.users;
using challenge.application.layer.api.Services.Users;
using challenge.domain.layer.api.Contracts;
using challenge.infrastructure.layer.api.ExternalApis.MicrosoftGraphApi;
using challenge.infrastructure.layer.api.HttpRequest;
using Microsoft.Extensions.DependencyInjection;

namespace challenge.bootstrapper.layer.api
{
    public static class StartupConfiguration
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped(typeof(IHttpService<>), typeof(HttpService<>));
            services.AddScoped<IMicrosoftGraphApiService, MicrosoftGraphApiService>();
        }

        public static void AddRepositories(this IServiceCollection services)
        {
        }

        public static void AddHelpers(this IServiceCollection services)
        {

        }

        public static void AddExternalServices(this IServiceCollection services)
        {
        }

        public static void AddSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen();
        }

    }
}
