using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Domain.Layer.Contracts;
<<<<<<< Updated upstream
using Domain.Layer.Models;
using Service.Layer.Specifications;
using ServiceAbstraction.Layer;
using Shared;
using Shared.DTOs;
=======
using Domain.Layer.Exceptions;
using Domain.Layer.Models.ProductModels;
using Service.Layer.Specifications;
using Service.Layer.Specifications.ProductModuleSpecification;
using ServiceAbstraction.Layer;
using Shared;
using Shared.DTOs.ProductDtos;
>>>>>>> Stashed changes

namespace Service.Layer
{
    public class ProductService(IUnitOfWork _unitOfWork, IMapper _mapper) : IProductService
    {

        public async Task<PaginatedResult<ProductDto>> GetAllProductsAsync(ProductQueryParams queryParams)
        {
            var repo = _unitOfWork.GetRepository<Product, int>();
            // Create Object from Specification
            var specs = new ProductWithBrandAndTypeSpecifications(queryParams);  // .Include(p => p.ProductType)Include(p => p.ProductBrand).
            //var products = await _unitOfWork.GetRepository<Product, int>().GetAllAsync(specs);
            var products = await repo.GetAllAsync(specs);
            var mappedProducts = _mapper.Map<IEnumerable<ProductDto>>(products);

            var countSpecs = new ProductCountSpecifications(queryParams);
            var totalCount = await repo.CountAsync(countSpecs);

            return new PaginatedResult<ProductDto>
                       (queryParams.PageIndex,queryParams.PageSize, totalCount, mappedProducts);
        }

        public async Task<ProductDto> GetProductByIdAsync(int id)
        {
            // Create Object from Specification
            var specs = new ProductWithBrandAndTypeSpecifications(id);
                                                                                       
            var product = await _unitOfWork.GetRepository<Product, int>().GetByIdAsync(specs);
<<<<<<< Updated upstream
=======

            if(product is null) 
                throw new ProductNotFoundException(id);

>>>>>>> Stashed changes
            return _mapper.Map<ProductDto>(product);
        }

        public async Task<IEnumerable<BrandDto>> GetAllBrandsAsync()
        {
            //var repo = _unitOfWork.GetRepository<ProductBrand, int>();
            //var brands = await repo.GetAllAsync();

            //OR Syntax
            var brands = await _unitOfWork.GetRepository<ProductBrand, int>().GetAllAsync();

            var brandsDtos = _mapper.Map<IEnumerable<BrandDto>>(brands);
            return brandsDtos;
        }
        public async Task<IEnumerable<TypeDto>> GetAllTypesAsync()
        {
            var types = await _unitOfWork.GetRepository<ProductType, int>().GetAllAsync();
            return _mapper.Map<IEnumerable<TypeDto>>(types);
        }

    }
}
