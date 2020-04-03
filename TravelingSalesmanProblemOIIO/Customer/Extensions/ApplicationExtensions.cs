using AppointmentProj.Persistance;
using ContactProj.Persistance;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContactProj.Extensions
{
    public static class ApplicationExtensions
    {
        public static void RegisterDependencies(this IServiceCollection services)
        {
            services.AddScoped<ContactRepository>();
            services.AddScoped<AppointmentRepository>();
        }
    }
}
