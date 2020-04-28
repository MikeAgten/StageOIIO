using ContactProj.Persistance;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestProject.ContactTests.Repository
{
    class ContactDbContextInMemory
    {
        public static ContactDbContext CreateInMemoryDbContext()
        {
            var builder = new DbContextOptionsBuilder<ContactDbContext>();
            builder.UseInMemoryDatabase(Guid.NewGuid().ToString());
            var dbcontext = new ContactDbContext(builder.Options);
            dbcontext.Database.EnsureCreated();
            return dbcontext;
        }
    }
}
