using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment.BLL.DTOs.DepartmentDTOs;
using Assignment.BLL.Factories;
using Assignment.BLL.Services.Interfaces;
using Assignment.DAL.Models;
using Assignment.DAL.Repositories.Interfaces;

namespace Assignment.BLL.Services.Classes
{
    public class DepartmentService(/*DepartmentRepository*/ IDepartmentRepository _departmentRepository) : IDepartmentService
    {
        //Mapping types:
        //{
        // Manual Mapping
        // Constructor Mapping (Manual Mapping)
        // Extension Method (Manual Mapping)
        // Auto Mapper
        //}

        //---------------------------------CRUD Operations-----------------------------------------

        #region Get All Department  (Manual Mapping)
        //public IEnumerable</*Department*/DepartmentDto> GetAllDepartments()
        //{
        //    var depts = _departmentRepository.GetAll();

        //    var departmentsToReturn = depts.Select(d => new DepartmentDto()       // Projection
        //    {
        //        DeptId = d.Id,
        //        Name = d.Name,
        //        Code = d.Code,
        //        Description = d.Description,
        //        DateOfCreation = DateOnly.FromDateTime(d.CreatedOn)               // Extract Date From DateTime
        //    }
        //    );

        //    return departmentsToReturn;
        //}

        // OR Syntax
        //public IEnumerable<DepartmentDto> GetAllDepartments()
        //=>
        //    _departmentRepository.GetAll().Select(d => new DepartmentDto()
        //    {
        //        DeptId = d.Id,
        //        Name = d.Name,
        //        Code = d.Code,
        //        Description = d.Description,
        //        DateOfCreation = DateOnly.FromDateTime(d.CreatedOn)
        //    }
        //    );

        #region (Extension Method Mapping)
        public IEnumerable<DepartmentDto> GetAllDepartments()
        {
            var dept = _departmentRepository.GetAll();
            var departmentsToReturn = dept.Select(d => d.ToDepartmentDto());  // Extension Method
            return departmentsToReturn;
        }

        #endregion

        #endregion

        #region Get Department By Id  (Manual Mapping)

        public DepartmentDetailsDto? GetDepartmentById(int id)
        {
            #region (Manual Mapping)

            //var dept = _departmentRepository.GetById(id);

            //if(dept is null)
            //    return null;
            //else
            //{
            //    var deptToReturn = new DepartmentDetailsDto()
            //    {
            //        Id = dept.Id,
            //        Name = dept.Name,
            //        Code = dept.Code,
            //        Description = dept.Description,
            //        DateOfCreation = DateOnly.FromDateTime(dept.CreatedOn),
            //        LastModifiedOn = DateOnly.FromDateTime(dept.LastModifiedOn),

            //        CreatedBy = dept.CreatedBy,
            //        LastModifiedBY = dept.LastModifiedBY,
            //        IsDeleted = dept.IsDeleted
            //    };

            //    return deptToReturn;


            // OR Syntax

            //var dept = _departmentRepository.GetById(id);
            //return dept == null ? null : new DepartmentDetailsDto()
            //{
            //    Id = dept.Id,
            //    Name = dept.Name,
            //    Code = dept.Code,
            //    Description = dept.Description,
            //    DateOfCreation = DateOnly.FromDateTime(dept.CreatedOn),
            //    LastModifiedOn = DateOnly.FromDateTime(dept.LastModifiedOn),

            //    CreatedBy = dept.CreatedBy,
            //    LastModifiedBY = dept.LastModifiedBY,
            //    IsDeleted = dept.IsDeleted
            //};
            #endregion

            #region (Constructor Mapping)
            //var dept = _departmentRepository.GetById(id);
            //return dept is null ? null : new DepartmentDetailsDto(dept);   //Constructor Mapping
            #endregion

            #region (Extension Method Mapping)

            var dept = _departmentRepository.GetById(id);
            return dept is null ? null : dept.ToDepartmentDetailsDto();   //Extension Method Mapping

            #endregion
        }

        #endregion

        #region Add New Department (Extension Method (Manual Mapping))
        public int AddDepartment(CreatedDepartmentDto departmentDto)
        {
            var entity = departmentDto.ToEntity();
            return _departmentRepository.Add(entity);
        }
        #endregion

        #region Update Department (Extension Method (Manual Mapping))
        public int UpdateDepartment(UpdateDepartmentDto departmentDto)
        {
            var entity = departmentDto.ToEntity();
            return _departmentRepository.Update(entity);
        }
        #endregion

        #region Delete Department
        public bool DeleteDepartment(int id)
        {
            var department = _departmentRepository.GetById(id);

            if (department is null)
                return false;
            else
            {
                var res = _departmentRepository.Delete(department);

                if (res > 0)
                    return true;
                else
                    return false;
            }
        }

        #endregion
    }

}








