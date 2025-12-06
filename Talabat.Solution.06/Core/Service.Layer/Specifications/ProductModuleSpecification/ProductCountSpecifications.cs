using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Layer.Models.ProductModels;
using Shared;

namespace Service.Layer.Specifications.ProductModuleSpecification
{
    public class ProductCountSpecifications : BaseSpecifications<Product, int>
    {
        //Get All Products with Types and Brands
        public ProductCountSpecifications(ProductQueryParams queryParams)
     : base(p => /*(!brandId.HasValue || brandId ==p.BrandId) &&
                   (!typeId.HasValue  || brandId == p.TypeId)*/
                   (!queryParams.BrandId.HasValue || queryParams.BrandId == p.BrandId) &&
                   (!queryParams.TypeId.HasValue || queryParams.BrandId == p.TypeId) &&
                   (string.IsNullOrWhiteSpace(queryParams.SearchValue) || p.Name.ToLower().Contains(queryParams.SearchValue.ToLower())))
        {
        }
    }
}
