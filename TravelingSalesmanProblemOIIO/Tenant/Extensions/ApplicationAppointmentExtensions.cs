using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using AppointmentProj.Persistance;
using AppointmentProj.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using AppointmentProj.Application.Appointments.Interfaces;
using AppointmentProj.Domain.Models;
using AppointmentProj.Persistence;

namespace AppointmentProj.Extensions
{
    public static class ApplicationAppointmentExtensions
    {
        public static void RegisterAppointmentDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            string connectionString = configuration.GetConnectionString("TSPAppointmentDatabase");
            services.AddScoped<AppointmentRepository>();
            services.AddScoped<AppointmentRequestRepository>();
            services.AddSingleton<AddressBook>();
            services.AddSingleton<TenantAddressBook>();
            services.AddDbContext<AppointmentDbContext>(options => options.UseSqlServer(connectionString), ServiceLifetime.Scoped);
            services.AddTransient<IGeneticAlgorithmService, GeneticAlgorithmService>();
        }
    }
}
