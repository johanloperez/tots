using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Builder;
using challenge.infrastructure.layer.api.HttpRequest;
using challenge.infrastructure.layer.api.ExternalApis.MicrosoftGraphApi;
using challenge.infrastructure.layer.api.AutoMapper;
using challenge.domain.layer.api.Contracts;

[assembly: InternalsVisibleTo("challenge.bootstrapper.layer")]
namespace challenge.infrastructure.layer.api
{
    public static class InfrastructureModule
    {
        public static IServiceCollection AddInfrastructureModule(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddScoped(typeof(IHttpService<>), typeof(HttpService<>));
            services.AddScoped<IMicrosoftGraphApiService, MicrosoftGraphApiService>();
            services.AddScoped<IUserMapper, UserMapper>();
            return services;
        }
        public static IApplicationBuilder UseInfrastructureModule(this IApplicationBuilder app, IConfiguration configuration)
        {
            return app;
        }

    }
}
