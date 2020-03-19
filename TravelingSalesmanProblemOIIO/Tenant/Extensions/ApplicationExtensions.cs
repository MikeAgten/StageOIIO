using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using AppointmentProj.Persistance;
using AppointmentProj.Domain;

namespace AppointmentProj.Extensions
{
    public static class ApplicationExtensions
    {
        public static void RegisterDependencies(this IServiceCollection services)
        {
            services.AddScoped<AppointmentRepository>();
        }
    }
}
