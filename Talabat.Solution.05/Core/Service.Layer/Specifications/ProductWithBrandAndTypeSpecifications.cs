using System;
using System.Buffers;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Layer.Models.ProductModels;
using Shared;

namespace Service.Layer.Specifications
{
    public class ProductWithBrandAndTypeSpecifications : BaseSpecifications<Product, int>
    {
        //Get All Products with Types and Brands
        //public ProductWithBrandAndTypeSpecifications() :base(null)
        //{
        //    AddInclude(p => p.ProductBrand); 
        //    AddInclude(p=>p.ProductType);
        //}
        public ProductWithBrandAndTypeSpecifications(ProductQueryParams queryParams) 
             : base(p => /*(!brandId.HasValue || brandId ==p.BrandId) &&
                           (!typeId.HasValue  || brandId == p.TypeId)*/
                           (!queryParams.BrandId.HasValue || queryParams.BrandId == p.BrandId) &&
                           (!queryParams.TypeId.HasValue || queryParams.BrandId == p.TypeId) &&
                           (string.IsNullOrWhiteSpace(queryParams.SearchValue) || p.Name.ToLower().Contains(queryParams.SearchValue.ToLower())))
        {
            //Where(p => p.BrandId == brandId && p.TypeId == typeId && p.Name.Contains("chicken"))

            AddInclude(p => p.ProductBrand);
            AddInclude(p => p.ProductType);

            switch (/*sortingOption*/ queryParams.SortingOption)
            {
                case ProductSortingOptions.NameAsc:
                    AddOrderBy(p => p.Name);
                    break;
                case ProductSortingOptions.NameDesc:
                    AddOrderByDescending(p => p.Name);
                    break;
                case ProductSortingOptions.PriceAsc:
                    AddOrderBy(p => p.Price);
                    break;
                case ProductSortingOptions.PriceDesc:
                    AddOrderByDescending(p => p.Price);
                    break;
                default:
                    //AddOrderBy(p => p.Id);
                    //or
                    //Make Enum startwith 1 (Explicit Values)
                    break;
            }

            ApplyPagination(queryParams.PageSize, queryParams.PageIndex);
        }

        //Get Product By Id with Type and Brand
        public ProductWithBrandAndTypeSpecifications(int id) : base(p => p.Id == id)
        {
            AddInclude(p => p.ProductBrand);
            AddInclude(p => p.ProductType);
        }
    }
}
