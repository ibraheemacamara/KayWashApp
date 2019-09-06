using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using KayWashApp.DataAccess.Model;

namespace KayWashApp.DataAccess
{
    public class KayWashAppContext : DbContext
    {
        public KayWashAppContext (DbContextOptions<KayWashAppContext> options)
            : base(options)
        {
        }

        public DbSet<KayWashApp.DataAccess.Model.Customer> Customer { get; set; }

        public DbSet<KayWashApp.DataAccess.Model.CarDetailer> CarDetailer { get; set; }

        public DbSet<KayWashApp.DataAccess.Model.Car> Car { get; set; }

        public DbSet<KayWashApp.DataAccess.Model.Admin> Admin { get; set; }

        public DbSet<KayWashApp.DataAccess.Model.WashPackage> WashPackage { get; set; }

        public DbSet<KayWashApp.DataAccess.Model.WashRequest> WashRequest { get; set; }

        public DbSet<KayWashApp.DataAccess.Model.Wash> Wash { get; set; }
    }
}
