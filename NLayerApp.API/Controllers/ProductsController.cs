using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NLayerApp.Core;
using NLayerApp.Core.DTOs;
using NLayerApp.Core.Services;

namespace NLayerApp.API.Controllers
{
    public class ProductsController : CustomBaseController
    {
        private readonly IMapper _mapper;

        private readonly IProductService _service;

        public ProductsController(IMapper mapper, IProductService service)
        {
            _mapper = mapper;
            _service = service;
        }
        //GET api/products/GetProductsWithCategory
        [HttpGet("[action]")]
        public async Task<IActionResult> GetProductsWithCategory()
        {
            return CreateActionResult(await _service.GetProductsWithCategory());
        }










        //GET api/products
        [HttpGet]
        public async Task<IActionResult> All() 
        {
            //alttaki iki katmani servis katmaninda yapmamiz daha bestpr tir
            var products =await _service.GetAllAsync();//bu bir entitydir o yuzden mapleme yapiyoruz
            var productsDtos = _mapper.Map<List<ProductDto>>(products.ToList());//async oldugu icin burdan bize IEnumerable donuyor o yuzden list e ceviriyoruz
            return CreateActionResult(CustomResponceDto<List<ProductDto>>.Success(200, productsDtos));
        }
        //GET api/products/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var products = await _service.GetByIdAsync(id);
            var productsDto = _mapper.Map<ProductDto>(products);
            return CreateActionResult(CustomResponceDto<ProductDto>.Success(200, productsDto));
        }
        [HttpPost]
        public async Task<IActionResult> Save(ProductDto productDto)
        {
            var product = await _service.AddAsync(_mapper.Map<Product>(productDto));
            var productsDto = _mapper.Map<ProductDto>(product);
            return CreateActionResult(CustomResponceDto<ProductDto>.Success(201, productsDto));
        }
        [HttpPut]
        public async Task<IActionResult> Update(ProductDto productDto)
        {
            await _service.UpdateAsync(_mapper.Map<Product>(productDto));
            return CreateActionResult(CustomResponceDto<NoContentDto>.Success(204));
        }
        //DELETE api/products/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var product=await _service.GetByIdAsync(id);
            if (product == null)
            {
                return CreateActionResult(CustomResponceDto<NoContentDto>.Fail(404,"Bu Id ye sahip urun bulunamadi"));

            }

             await _service.RemoveAsync(product);
            return CreateActionResult(CustomResponceDto<NoContentDto>.Success(200));
        }


    }
}
