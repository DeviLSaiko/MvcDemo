namespace DemoMvc.Models
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class Garments : DbContext
    {
        public DbSet<Users> users { get; set; }
        public DbSet<Departments> departments { get; set; }

        public System.Data.Entity.DbSet<Database1.Db> Dbs { get; set; }
    }
}

    