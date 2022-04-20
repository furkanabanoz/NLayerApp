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
    internal class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(x => x.Id);//pk yapiyoruz id yi
            builder.Property(x => x.Id).UseIdentityColumn();//id degeri birer birer artar
            builder.Property(x=>x.Name).IsRequired().HasMaxLength(50);//null olmayacagini belirtiyoruz ve arkasindan max karakterini 50 olarak belirityoruz
            builder.ToTable ("Categories");//normade appDbContext te beliritiyoruz tablomuzun adini ancak istersek buradan da kolayca yapabiliriz

        }
    }
}
