namespace DemoMvc.Models
{
    using OrdersProject;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class GarmentsProDb : DbContext
    {
        public DbSet<Users> users { get; set; }
        public DbSet<Departments> departments { get; set; }
        public DbSet<Orders> Orders { get; set; }
        
    }
}

    