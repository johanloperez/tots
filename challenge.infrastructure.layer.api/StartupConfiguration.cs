namespace Challenge.bootstrapper.layer.api.Infrastructure
{
    public static class StartupConfiguration
    {
        public static void AddServices(this IServiceCollection services)
        {
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
