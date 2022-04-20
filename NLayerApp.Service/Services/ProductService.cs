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
    public class ProductService : Service<Product>, IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        public ProductService(IUnitOfWork unitOfWork, IGenericRepository<Product> repository, IMapper mapper, IProductRepository productRepository) : base(unitOfWork, repository)
        {
            _mapper = mapper;
            _productRepository = productRepository;
        }

        public async Task<CustomResponceDto<List<ProductWithCategoryDto>>> GetProductsWithCategory()
        {
            var products = await _productRepository.GetProductWithCategory();
            var productsDto = _mapper.Map<List<ProductWithCategoryDto>>(products);
            return CustomResponceDto<List<ProductWithCategoryDto>>.Success(200, productsDto);
        }

    }
}
