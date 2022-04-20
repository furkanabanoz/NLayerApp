﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NLayerApp.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayerApp.Repository.Configurations
{
    internal class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).HasMaxLength(50).IsRequired();
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x=>x.Stock).IsRequired();
            builder.Property(x=>x.Price).IsRequired().HasColumnType("decimal(18,2)");//virgulden sonra 2 karakter oncesinde ise 16 karakter toplam 18 karakter 
            builder.ToTable("Products");

            //1-n bagalnti oldugunu gosteriyoruz
            builder.HasOne(x=>x.Category).WithMany(x=>x.Products).HasForeignKey(x=>x.CategoryId);
        }
    }
}
