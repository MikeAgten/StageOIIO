using AppointmentProj.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AppointmentProj.Persistance
{
    public class AppointmentDbContext : DbContext
    {

        public AppointmentDbContext() : base()
        { }
        public AppointmentDbContext(DbContextOptions<AppointmentDbContext> options): base(options)
        { }

        public DbSet<Appointment> Appointments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Appointment>().HasKey(t => t.Id);
        }
    }
}

