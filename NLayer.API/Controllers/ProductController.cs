using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NLayer.Core.DTOs;
using NLayer.Core.Models;
using NLayer.Core.Services;

namespace NLayer.API.Controllers
{

    public class ProductController : CustomBaseController
    {
        private readonly IMapper _mapper;
        private readonly IProductService _productService;

        public ProductController(IService<Product> service, IMapper mapper, IProductService productService)
        {
            _mapper=mapper;
            _productService=productService;
        }

        //Get api/product/GetProductsWithCategory
        [HttpGet("[action]")]
        public async Task<IActionResult> GetProductsWithCategory()
        {
            return CreateActionResult(await _productService.GetProductsWithCategory());
        }



        // Get api/product
        [HttpGet]
        public async Task<IActionResult> All()
        {
            var products = await _productService.GetAllAsync();
            var productDtos = _mapper.Map<List<ProductDTO>>(products.ToList());

            return CreateActionResult(CustomResponseDTO<List<ProductDTO>>.Success(200, productDtos));

        }

        // api/product/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _productService.GetByIdAsync(id);
            var productDto = _mapper.Map<ProductDTO>(product);

            return CreateActionResult(CustomResponseDTO<ProductDTO>.Success(200, productDto));
        }

        [HttpPost]
        public async Task<IActionResult> Save(ProductDTO productDto)
        {
            var product = await _productService.AddAsync(_mapper.Map<Product>(productDto));
            var productsDto = _mapper.Map<ProductDTO>(product);
            return CreateActionResult(CustomResponseDTO<ProductDTO>.Success(201, productsDto));
        }

        [HttpPut]
        public async Task<IActionResult> Update(ProductUpdateDTO productUpdateDto)
        {
            await _productService.UpdateAsync(_mapper.Map<Product>(productUpdateDto));

            return CreateActionResult(CustomResponseDTO<NoContentDTO>.Success(204));
        }

        // Delete api/product/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var product = await _productService.GetByIdAsync(id);
            await _productService.RemoveAsync(product);

            return CreateActionResult(CustomResponseDTO<NoContentDTO>.Success(204));

        }

    }
}
