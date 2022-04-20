using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NLayerApp.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayerApp.Repository.Seeds
{
    internal class ProductSeed : IEntityTypeConfiguration<Product>
    {

        //category id si kalemler yani kalemle ilgili data verecegiz
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData(
                new Product { Id = 1, Name = "KursunKalem", CategoryId = 1 ,Stock=20,CreatedDate=DateTime.Now },//ileride datetime i base bi classta verecez surekli vermemize gerek kalmayacak


                new Product { Id = 2, Name = "TukenmezKalem", CategoryId = 1, Stock = 30, CreatedDate = DateTime.Now },//ileride datetime i base bi classta verecez surekli vermemize gerek kalmayacak

                new Product { Id = 3, Name = "Kalem", CategoryId = 1, Stock = 20, CreatedDate = DateTime.Now },//ileride datetime i base bi classta verecez surekli vermemize gerek kalmayacak


                new Product { Id = 4, Name = "KursunKalem", CategoryId = 2, Stock = 20, CreatedDate = DateTime.Now }//ileride datetime i base bi classta verecez surekli vermemize gerek kalmayacak
                
                );
        }
    }
}
