using Microsoft.Extensions.DependencyInjection;

namespace Api
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApiDependencies(this IServiceCollection services)
        {
            services.AddTransient<IMission, Mission>();

            return services;
        }
    }
}