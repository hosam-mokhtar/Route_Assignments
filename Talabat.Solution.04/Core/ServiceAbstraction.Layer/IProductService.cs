using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.DTOs;

namespace ServiceAbstraction.Layer
{
    public interface IProductService
    {
        //GetAllProducts
        Task<IEnumerable<ProductDto>> GetAllProductsAsync();


        //Get Product By Id
        Task<ProductDto> GetProductByIdAsync(int id);

        //Get All Brands
        Task<IEnumerable<BrandDto>> GetAllBrandsAsync();

        //Get All Types
        Task<IEnumerable<TypeDto>> GetAllTypesAsync();
    }
}
