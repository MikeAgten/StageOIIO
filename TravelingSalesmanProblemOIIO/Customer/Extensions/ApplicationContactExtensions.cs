using AppointmentProj.Persistance;
using ContactProj.Persistance;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

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
