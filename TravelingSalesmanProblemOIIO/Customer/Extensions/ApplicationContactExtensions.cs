using ContactProj.Persistance;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ContactProj.Extensions
{
    public static class ApplicationContactExtensions
    {
        public static void RegisterContactDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            string connectionString = configuration.GetConnectionString("TSPContactDatabase");
            services.AddScoped<ContactRepository>();
            services.AddDbContext<ContactDbContext>(options => options.UseSqlServer(connectionString), ServiceLifetime.Scoped);
        }
    }
}
