using AutoMapper;
using NLayerApp.Core;
using NLayerApp.Core.DTOs;
using NLayerApp.Core.Repositories;
using NLayerApp.Core.Services;
using NLayerApp.Core.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayerApp.Service.Services
{
    public class CategoryService : Service<Category>, ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryService(IUnitOfWork unitOfWork, IGenericRepository<Category> repository, ICategoryRepository categoryRepository, IMapper mapper) : base(unitOfWork, repository)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<CustomResponceDto<CategoryWithProductDto>> GetSingleCategoryByWithProductsAsync(int categoryId)
        {
            var category = await _categoryRepository.GetSingleCategoryByWithProductsAsync(categoryId);
            var categoryDto=_mapper.Map<CategoryWithProductDto>(category);
            return CustomResponceDto<CategoryWithProductDto>.Success(200,categoryDto);
        }
    }
}
