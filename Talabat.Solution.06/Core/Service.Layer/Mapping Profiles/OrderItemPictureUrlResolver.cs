using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DomainLayer.Models.OrderModels;
using Microsoft.Extensions.Configuration;
using Shared.DTOs.OrderDtos;

namespace Service.Layer.Mapping_Profiles
{
    public class OrderItemPictureUrlResolver(IConfiguration _configuration) 
               : IValueResolver<OrderItem, OrderItemDto, string>
    {
        public string Resolve(OrderItem source, OrderItemDto destination, string destMember, ResolutionContext context)
        {
            if (string.IsNullOrEmpty(source.Product.PictureUrl)) 
                return string.Empty;
            else
            {
                var pictureUrl = _configuration.GetSection("Urls")["BaseUrl"];
                return $"{pictureUrl}{source.Product.PictureUrl}";
            }
        }
    }
}
