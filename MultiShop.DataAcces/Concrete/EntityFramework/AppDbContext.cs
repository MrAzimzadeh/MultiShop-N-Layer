using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MultiShop.Entities.Concreate;

namespace MultiShop.DataAcces.Concrete.EntityFramework
{
    /*
     * 
     *
     */
    public class AppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer
            ("Server=127.0.0.1,1433;Database=MultiShopDBTest; User Id=SA; Password=Mahammad123456; TrustServerCertificate=True;");
        }

        public DbSet<Product> Products { get; set; }
    }
}
