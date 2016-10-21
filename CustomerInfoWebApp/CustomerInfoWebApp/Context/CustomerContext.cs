using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using CustomerInfoWebApp.Models;

namespace CustomerInfoWebApp.Context
{
    public class CustomerContext:DbContext
    {
        public CustomerContext() : base("CustomerConnection") { }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Designation> Designations { get; set; }
        public DbSet<Region> Regions { get; set; }

    }
}