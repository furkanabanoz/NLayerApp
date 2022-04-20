using NLayerApp.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayerApp.Core.Services
{
    public interface IProductService:IService<Product>
    {
        Task<CustomResponceDto<List<ProductWithCategoryDto>>> GetProductsWithCategory();//mapping islemini burada yaptigindan controllerde o kadar uzun kodlar yazma zorunda kalmiyoruz
    }
}
