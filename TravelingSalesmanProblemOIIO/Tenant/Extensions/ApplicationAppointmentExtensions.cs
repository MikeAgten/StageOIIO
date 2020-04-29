using AppointmentProj.Application.Appointments.Interfaces;
using AppointmentProj.Persistance;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppointmentProj.Extensions
{
    public static class ApplicationAppointmentExtensions
    {
        public static void RegisterAppointmentDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            string connectionString = configuration.GetConnectionString("TSPContactDatabase");
            services.AddScoped<AppointmentRepository>();
            services.AddDbContext<AppointmentDbContext>(options => options.UseSqlServer(connectionString));

            services.AddScoped<IGeneticAlgorithmService, GeneticAlgorithmService>();
        }
    }
}
