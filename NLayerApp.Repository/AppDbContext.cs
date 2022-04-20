using Microsoft.EntityFrameworkCore;
using NLayerApp.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NLayerApp.Repository
{
    public class AppDbContext:DbContext
    {
        //DbContextOptions olmasinin sebeni veri tabani yolunu startup dosyasi uzerinden verecegiz
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {

        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductFeature> ProductFeatures { get; set; }//gercek hayatta product uzerinden erisebilmemiz lazim productFeature e ama ogrenme maksatli olarak suanlik yapmiyoruz


        //entitylerle ilgili ayarlari yapabilmemiz icin migration esnasinda 
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());//yani diyor ki git bu class librarylere(bunlar assembly) tum configuration dosyalarini oku
            //                                                    calismis oldugumuz assembly i tara diyoruz
            modelBuilder.Entity<ProductFeature>().HasData(new ProductFeature() 
            {
                Id = 1,
                Color ="Red",
                Height =100,
                Width =200,
                ProductId = 1
            },
            new ProductFeature()
            {
                Id = 2,
                Color = "Blue",
                Height = 100,
                Width = 200,
                ProductId = 2 
            });
            base.OnModelCreating(modelBuilder);
        }
    }
}
