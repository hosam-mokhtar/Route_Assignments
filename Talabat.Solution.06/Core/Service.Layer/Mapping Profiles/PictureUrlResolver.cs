using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
<<<<<<< Updated upstream
using Domain.Layer.Models;
using Microsoft.Extensions.Configuration;
using Shared.DTOs;
=======
using Domain.Layer.Models.ProductModels;
using Microsoft.Extensions.Configuration;
using Shared.DTOs.ProductDtos;
>>>>>>> Stashed changes

namespace Service.Layer.Mapping_Profiles
{
    internal class PictureUrlResolver(IConfiguration _configuration) : IValueResolver<Product, ProductDto, string>
    {
        public string Resolve(Product source, ProductDto destination, string destMember, ResolutionContext context)
        {
            if (string.IsNullOrWhiteSpace(source.PictureUrl))
                return string.Empty;
            else
            {
                //var url = $"http://localhost:5013/{source.PictureUrl}";
                var url = $"{_configuration.GetSection("Urls")["BaseUrl"]}{source.PictureUrl}";
                return url;
            }

        }
    }
}
