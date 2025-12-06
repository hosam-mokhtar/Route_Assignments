using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Layer.Models.ProductModels
{
    public class Product :BaseEntity<int>
    {
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string PictureUrl { get; set; } = null!;
        public decimal Price { get; set; }

        //Relationship (1-M) ProductBrand - Product
        public int BrandId { get; set; }
        public ProductBrand ProductBrand { get; set; }

        //Relationship (1-M) ProductType - Product
        public int TypeId { get; set; }
        public ProductType ProductType { get; set; }
    }
}
