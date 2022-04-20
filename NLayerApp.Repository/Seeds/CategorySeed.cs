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
    internal class CategorySeed : IEntityTypeConfiguration<Category>
    {//migration olusurken ilgili default kayitlarimizin olusmasini istiyorsak idleri kendimiz vermiz gerekiyor
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            //id yi sadece seed data kisminda veriyoruz 
            builder.HasData(new Category { Id = 1, Name = "Kalemler" });

            builder.HasData(new Category { Id = 2, Name = "Kitaplar" });

            builder.HasData(new Category { Id = 3, Name = "Defterler" });
        }
    }
}
