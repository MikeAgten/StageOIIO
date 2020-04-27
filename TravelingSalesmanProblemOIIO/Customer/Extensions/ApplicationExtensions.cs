using ContactProj.Persistance;
using Microsoft.Extensions.DependencyInjection;

namespace ContactProj.Extensions
{
    public static class ApplicationExtensions
    {
        public static void RegisterDependencies(this IServiceCollection services)
        {
            services.AddScoped<ContactRepository>();
        }
    }
}
