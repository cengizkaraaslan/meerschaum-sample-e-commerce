using eticaret.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eticaret.DataAccess
{
    public class MeerschaumContext : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            IConfigurationRoot configuration = builder.Build();
#if DEBUG
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnectiondebug"));
#else
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
#endif


            //optionsBuilder.UseSqlServer(@"Server=.;Database=Meerschaum; Trusted_Connection=true");
            // base.OnConfiguring(optionsBuilder);
        }
        public DbSet<Products> Products { get; set; }
        public DbSet<Models.ProductModel> Products_category { get; set; }
        public DbSet<Photo> Photos { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<UnderCategory> UnderCategory { get; set; }
        public DbSet<MotherCategory> MotherCategory { get; set; }
        public DbSet<Salesed> Salesed { get; set; }
        public DbSet<Sales_Product> Sales_Product { get; set; }
        public DbSet<Users> Users { get; set; }
    }
    public class MeerschaumContext2 : DbContext
    {
        public MeerschaumContext2(DbContextOptions<MeerschaumContext2> options) : base(options)
        {
        }
        public DbSet<Products> Products { get; set; }
        public DbSet<Models.ProductModel> Products_category { get; set; }
        public DbSet<Photo> Photos { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<UnderCategory> UnderCategory { get; set; }
        public DbSet<MotherCategory> MotherCategory { get; set; }
        public DbSet<Salesed> Salesed { get; set; }
        public DbSet<Sales_Product> Sales_Product { get; set; }
        public DbSet<Users> Users { get; set; }
    }
}
