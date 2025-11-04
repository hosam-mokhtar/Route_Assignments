using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment.BLL.DTOs.EmployeeDTOs;
using Assignment.DAL.Models.EmployeeModel;
using AutoMapper;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Assignment.BLL.Mapping_Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            //CreateMap<Employee, EmployeeDto>(); // From Employee to Employee Dto
            //CreateMap<EmployeeDto, Employee>(); // From Employee Dto to Employee

            // ReverseMap() =>  From Employee to Employee Dto & and From Employee Dto to Employee


            CreateMap<Employee, EmployeeDto>()
                //Because differnt between (Name & Type)
                .ForMember(dest => dest.EmpGender, Options => Options.MapFrom(src => src.Gender))
                .ForMember(dest => dest.EmpType, Options => Options.MapFrom(src => src.EmployeeType))   
                .ReverseMap(); 

            CreateMap<Employee, EmployeeDetailsDto>()
                //Because differnt between (Type)
                .ForMember(dest => dest.Gender, Options => Options.MapFrom(src => src.Gender))
                .ForMember(dest => dest.EmployeeType, Options => Options.MapFrom(src => src.EmployeeType))
                .ForMember(dest => dest.HiringDate, Options => Options.MapFrom(src => DateOnly.FromDateTime(src.HiringDate)))
                .ReverseMap();

            CreateMap<CreatedEmployeeDto, Employee>()
                     .ForMember(dest => dest.HiringDate, Options => Options.MapFrom(src => src.HiringDate.ToDateTime(new TimeOnly())))
                     .ReverseMap();

            CreateMap<UpdatedEmployeeDto, Employee>()
                     .ForMember(dest => dest.HiringDate, Options => Options.MapFrom(src => src.HiringDate.ToDateTime(new TimeOnly())))
                     .ReverseMap();
        }

    }
}
