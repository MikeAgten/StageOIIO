using ContactProj.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContactProj.Persistance
{
    public class ContactDbContext : DbContext
    {
        public ContactDbContext(DbContextOptions<ContactDbContext> options) : base(options)
        { }

        public DbSet<Contact> Contacts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new ContactConfiguration());
            modelBuilder.Entity<Contact>().HasKey(c => c.Id);
        }

        public class ContactConfiguration : IEntityTypeConfiguration<Contact>
        {
            public void Configure(EntityTypeBuilder<Contact> builder)
            {
                builder.HasKey(e => e.Id);
            }
        }
       
        public class ContactDbContextFactory : IDesignTimeDbContextFactory<ContactDbContext>
        {
            public ContactDbContext CreateDbContext(string[] args)
            {
                var optionsBuilder = new DbContextOptionsBuilder<ContactDbContext>();
                optionsBuilder.UseSqlServer("Server = (localdb)\\mssqllocaldb; Database = TSPContactDatabase; Trusted_Connection = True;"); // todo - vervang connectionstring
                return new ContactDbContext(optionsBuilder.Options);
            }
        }
    }
}