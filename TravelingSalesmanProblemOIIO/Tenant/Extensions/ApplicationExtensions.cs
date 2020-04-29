using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using AppointmentProj.Persistance;
using AppointmentProj.Domain;
using AppointmentProj.Application.Appointments.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace AppointmentProj.Extensions
{
    public static class ApplicationExtensions
    {
        public static void AAARegisterAppointmentDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            //string connectionString = "Server = (localdb)\\mssqllocaldb; Database = TSPAppointmentDatabase; Trusted_Connection = True;";
            //services.AddDbContext<AppointmentDbContext>(options => options.UseSqlServer(connectionString), ServiceLifetime.Scoped);
            //services.AddMediatR(typeof(AppointmentRepository).Assembly);
            //services.AddScoped<AppointmentRepository>();
            //services.AddTransient<IGeneticAlgorithmService, GeneticAlgorithmService>();

        }
    }
}
