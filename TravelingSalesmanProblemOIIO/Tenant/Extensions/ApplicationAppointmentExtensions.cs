using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using AppointmentProj.Persistance;
using AppointmentProj.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using AppointmentProj.Domain.Models;
using AppointmentProj.Persistence;
using AppointmentProj.Application.Services.AddressBookServices;
using AppointmentProj.Application.Services.AlgorithmServices;
using AppointmentProj.Application.Services.SchedulerServices;

namespace AppointmentProj.Extensions
{
    public static class ApplicationAppointmentExtensions
    {
        public static void RegisterAppointmentDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            string connectionString = configuration.GetConnectionString("TSPAppointmentDatabase");
            services.AddScoped<AppointmentRepository>();
            services.AddScoped<AppointmentRequestRepository>();
            services.AddScoped<AppointmentScheduler>();
            services.AddSingleton<AddressBook>();
            services.AddSingleton<TenantAddressBook>();
            services.AddDbContext<AppointmentDbContext>(options => options.UseSqlServer(connectionString), ServiceLifetime.Scoped);
            services.AddTransient<IGeneticAlgorithmService, GeneticAlgorithmService>();
        }
    }
}
