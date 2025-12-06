using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Domain.Layer.Models.IdentityModels;
using Shared.DTOs.IdentityDtos;

namespace Service.Layer.Mapping_Profiles
{
    public class IdentityMappingProfile : Profile
    {
        public IdentityMappingProfile()
        {
            CreateMap<Address, AddressDto>().ReverseMap();
        }
    }
}
