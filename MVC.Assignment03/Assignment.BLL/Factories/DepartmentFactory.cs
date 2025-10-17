using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment.BLL.DTOs;
using Assignment.DAL.Models;

namespace Assignment.BLL.Factories
{
    static public class DepartmentFactory
    {
        static public DepartmentDto ToDepartmentDto(this Department department)
        {
            return new DepartmentDto
            {
                DeptId = department.Id,
                Name = department.Name,
                Code = department.Code,
                Description = department.Description,
                DateOfCreation = DateOnly.FromDateTime(department.CreatedOn)
            };
        }

        static public DepartmentDetailsDto ToDepartmentDetailsDto(this Department dept)
        {
            return new DepartmentDetailsDto()
            {
                Id = dept.Id,
                Name = dept.Name,
                Code = dept.Code,
                Description = dept.Description,
                DateOfCreation = DateOnly.FromDateTime(dept.CreatedOn),
                LastModifiedOn = DateOnly.FromDateTime(dept.LastModifiedOn),

                CreatedBy = dept.CreatedBy,
                LastModifiedBY = dept.LastModifiedBY,
                IsDeleted = dept.IsDeleted
            };
        }

        static public Department ToEntity(this CreeatedDepartmentDto dto)
        {
            return new Department()
            {
                Name = dto.Name,
                Code = dto.Code,
                Description = dto.Description,
                CreatedOn = dto.DateOfCreation.ToDateTime(new TimeOnly())
            };
        }


        //---------------------------------Overloading---------------------------
        static public Department ToEntity(this UpdateDepartmentDto dto)
        {
            return new Department()
            {

                Id = dto.Id,


                Name = dto.Name,
                Code = dto.Code,
                Description = dto.Description,
                CreatedOn = dto.DateOfCreation.ToDateTime(new TimeOnly())
            };
        }

    }
}
