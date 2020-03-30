﻿using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using AppointmentProj.Persistance;
using AppointmentProj.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace AppointmentProj.Extensions
{
    public static class ApplicationAppointmentExtensions
    {
        public static void RegisterAppointmentDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            string connectionString = configuration.GetConnectionString("TSPAppointmentDatabase");
            services.AddScoped<AppointmentRepository>();
            services.AddDbContext<AppointmentDbContext>(options => options.UseSqlServer(connectionString), ServiceLifetime.Scoped);
        }
    }
}