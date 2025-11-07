using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Domain.Layer.Models;
using Shared.DTOs;

namespace Service.Layer.Mapping_Profiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductDto>()
                .ForMember(dest => dest.BrandName, options => options.MapFrom(src => src.ProductBrand.Name))
                .ForMember(dest => dest.TypeName, options => options.MapFrom(src => src.ProductType.Name))
                .ForMember(dest => dest.PictureUrl, 
                         //options => options.MapFrom(src => $"http://localhost:5013/{src.PictureUrl}"));
                           options => options.MapFrom<PictureUrlResolver>());

            CreateMap<ProductType, TypeDto>().ReverseMap();
            CreateMap<ProductBrand, BrandDto>();
        }
    }
}
