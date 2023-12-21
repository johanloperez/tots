using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Builder;
using challenge.infrastructure.layer.HttpRequest;
using challenge.infrastructure.layer.ExternalApis.MicrosoftGraphApi;
using challenge.infrastructure.layer.AutoMapper;
using challenge.domain.layer.Contracts;

[assembly: InternalsVisibleTo("challenge.bootstrapper.layer")]
namespace challenge.infrastructure.layer
{
    public static class InfrastructureModule
    {
        public static IServiceCollection AddInfrastructureModule(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("Default");

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddScoped(typeof(IHttpService<>), typeof(HttpService<>));
            services.AddScoped<IMicrosoftGraphApiService, MicrosoftGraphApiService>();
            //services.AddDbContext<DbContext>(options => options.UseSqlServer(connectionString));
            services.AddScoped<IUserMapper, UserMapper>();
            services.AddScoped<IEventMapper, EventMapper>();
            return services;
        }
        public static IApplicationBuilder UseInfrastructureModule(this IApplicationBuilder app, IConfiguration configuration)
        {
            return app;
        }

    }
}
