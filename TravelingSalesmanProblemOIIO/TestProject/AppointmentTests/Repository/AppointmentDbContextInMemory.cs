using AppointmentProj.Persistance;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestProject.AppointmentTests.Repository
{
    public static class AppointmentDbContextInMemory
    {
        public static AppointmentDbContext CreateInMemoryDbContext()
        {
            var builder = new DbContextOptionsBuilder<AppointmentDbContext>();
            builder.UseInMemoryDatabase(Guid.NewGuid().ToString());
            var dbcontext = new AppointmentDbContext(builder.Options);
            dbcontext.Database.EnsureCreated();
            return dbcontext;
        }
    }
}
