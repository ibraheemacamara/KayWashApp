using KayWashApp.Common;
using KayWashApp.DataBase.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KayWashApp.DataBase
{
    public class KayWashDbContext : DbContext
    {
        public static string DbConnectionString = "Server=localhost; Database=KayWash; Trusted_Connection=True;";
        public KayWashDbContext(DbContextOptions<KayWashDbContext> options)
            : base(options)
        {

        }

        public KayWashDbContext()
        {

        }

        public DbSet<Washer> Washers { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Car> Cars { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Washer>().HasData(new Washer
            {
                Id = 1,
                Name = "Ibrahima Camara",
                Username = "icamara",
                Status = UserStatus.ACTIVE,
                Password = "icamara"
            });
            modelBuilder.Entity<Washer>().HasData(new Washer
            {
                Id = 2,
                Name = "Ibou Cmr",
                Username = "ikacmr",
                Status = UserStatus.ACTIVE,
                Password = "ikacmr"
            });

            modelBuilder.Entity<Car>().HasData(new Car
            {
                Id = 1,
                Brand = "Renault",
                Model = "Clio IV"
            });
            modelBuilder.Entity<Car>().HasData(new Car
            {
                Id = 2,
                Brand = "Peugeot",
                Model = "406"
            });
        }
    }
}
