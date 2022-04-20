﻿using NLayerApp.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayerApp.Core.Services
{
    public interface ICategoryService:IService<Category>
    {
        public Task<CustomResponceDto<CategoryWithProductDto>> GetSingleCategoryByWithProductsAsync(int categoryId);
    }
}
