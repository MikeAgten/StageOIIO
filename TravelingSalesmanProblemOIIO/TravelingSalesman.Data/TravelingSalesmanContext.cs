using Microsoft.EntityFrameworkCore;
using CustomerProj.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace TravelingSalesman.Data
{
    public class TravelingSalesmanContext : DbContext
    {
        public DbSet<CustomerProj.Domain.Customer> Customers { get; set; }
    }
}
