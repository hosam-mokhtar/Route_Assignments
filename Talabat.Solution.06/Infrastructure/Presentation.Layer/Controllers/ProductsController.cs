using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ServiceAbstraction.Layer;
using Shared;
using Shared.DTOs;

namespace Presentation.Layer.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class ProductsController(IServiceManager _serviceManager) : ControllerBase
    {
        // Get All Products
        [HttpGet]                         // Get :: BaseUrl/api/Products
        public async Task<ActionResult<IEnumerable<PaginatedResult<ProductDto>>>> GetAllProducts([FromQuery] ProductQueryParams queryParams)
        {
            var products = await _serviceManager.ProductService.GetAllProductsAsync(queryParams);
            return Ok(products);

        }


        //Get Product By Id
        //[HttpGet]                   //Conflict =>  Get :: BaseUrl/api/Products?id=5         
        [HttpGet("{id}")]                         // Get :: BaseUrl/api/Products/5
        public async Task<ActionResult<ProductDto>> GetProductById(int id)
        {
            var product = await _serviceManager.ProductService.GetProductByIdAsync(id);
            return Ok(product);
        }


        //Get All Types
        [HttpGet("types")]                        // Get :: BaseUrl/api/Products/types
        public async Task<ActionResult<IEnumerable<TypeDto>>> GetAllTypes()
        {
            var types = await _serviceManager.ProductService.GetAllTypesAsync();
            return Ok(types);
        }


        //Get All Brands
        [HttpGet("brands")]                        // Get :: BaseUrl/api/Products/brands
        public async Task<ActionResult<IEnumerable<BrandDto>>> GetAllBrands()
        {
            var brands = await _serviceManager.ProductService.GetAllBrandsAsync();
            return Ok(brands);
        }
    }
}
