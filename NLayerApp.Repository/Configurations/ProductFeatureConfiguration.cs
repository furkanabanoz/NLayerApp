using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NLayerApp.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayerApp.Repository.Configurations
{
    internal class ProductFeatureConfiguration : IEntityTypeConfiguration<ProductFeature>
    {
        public void Configure(EntityTypeBuilder<ProductFeature> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x=>x.Id).UseIdentityColumn();
            //1 -1 baglantili oldugunu gosteriyoruz @ 1-1 iliksi oldugu icin foreingKey i acik acik veriyoruz
            builder.HasOne(x=>x.product).WithOne(x=>x.ProductFeature).HasForeignKey<ProductFeature>(x=>x.ProductId);   

             
        }
    }
}
