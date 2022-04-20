using AutoMapper;
using NLayerApp.Core.DTOs;
using NLayerApp.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayerApp.Service.Mapping
{
    public class MapProfile:Profile
    {
        public MapProfile()
        {
            CreateMap<Product,ProductDto>().ReverseMap();//reverse map diyince her iki tarafa da cevrilir
            CreateMap<Category,CategoryDto>().ReverseMap();
            CreateMap<ProductFeature, ProductFeatureDto>().ReverseMap();
            CreateMap<ProductUpdateDto, Product>();//ancak burada sadece dto dan product a cevirme var
            CreateMap<Product, ProductWithCategoryDto>();
            CreateMap<Category, CategoryWithProductDto>();


        }

    }
}
