using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Assignment.BLL.DTOs.EmployeeDTOs;
using Assignment.BLL.Services.Interfaces;
using Assignment.DAL.Models.EmployeeModel;
using Assignment.DAL.Models.Shared;
using Assignment.DAL.Repositories.Interfaces;
using AutoMapper;
using Azure;

namespace Assignment.BLL.Services.Classes
{
    public class EmployeeService(IEmployeeRepository _employeeRepository, IMapper _mapper) : IEmployeeService
    {
        public IEnumerable<EmployeeDto> GetAllEmployees(bool withTracking = false)
        {

            #region Manual Mapping
            //var employees = _employeeRepository.GetAll();
            //var employeesDto = employees.Select(emp => new EmployeeDto()
            //{
            //    Id = emp.Id,
            //    Name = emp.Name,
            //    Age = emp.Age,
            //    Email = emp.Email,
            //    Salary = emp.Salary,
            //    IsActive = emp.IsActive,
            //    EmployeeType = emp.EmployeeType.ToString(),
            //    Gender = emp.Gender.ToString()
            //});
            #endregion

            #region Auto Mapper

            #region GetAll()

            //var employees = _employeeRepository.GetAll();

            //                                Source                Destination    Source
            //return _mapper.Map<IEnumerable<Employee>, IEnumerable<EmployeeDto>>(employees);

            //or syntax

            //                              Destination    Source
            //return _mapper.Map<IEnumerable<EmployeeDto>>(employees);

            #endregion

            #region GetAll(selector)

            var employees = _employeeRepository.GetAll(e => new EmployeeDto()
            {
                Id = e.Id,
                Name = e.Name,
                Salary = e.Salary,
                Age = e.Age,
                Email = e.Email,
                EmpType = e.EmployeeType.ToString(),
                EmpGender = e.Gender.ToString(),


                Department = e.Department == null ? null : e.Department.Name



            })/*;*/.Where(e => e.Age > 25);

             return employees;

            #endregion

            #endregion

            #region IEnumerable

            //var result = _employeeRepository.GetIEnumerable()
            //                        .Where(e => e.IsDeleted == false)
            //                        .Select(e => new EmployeeDto()
            //                        {
            //                            Id = e.Id,
            //                            Name = e.Name,
            //                            Age = e.Age,
            //                        }
            //                        );
            //return result;
            //return result.ToList();

            //SELECT *
            //FROM[Employees] AS[e] 

            #endregion

            #region IQueryable

            //var result = _employeeRepository.GetIQueryable()
            //                        .Where(e => e.IsDeleted == false)
            //                        .Select(e => new EmployeeDto()
            //                        {
            //                            Id = e.Id,
            //                            Name = e.Name,
            //                            Age = e.Age,
            //                        }
            //                        );
            //return result.ToList();

            //SELECT[e].[Id], [e].[Name], [e].[Age]
            //FROM[Employees] AS[e]
            //WHERE[e].[IsDeleted] = CAST(0 AS bit)

            #endregion

        }

        public EmployeeDetailsDto? GetEmployeeById(int id)
        {
            var employee = _employeeRepository.GetById(id);

            #region Manual Mapping
            //var employeeDto = new EmployeeDetailsDto()
            //{
            //    Id = employee.Id,
            //    Name = employee.Name,
            //    Age = employee.Age,
            //    Email = employee.Email,
            //    PhoneNumber = employee.PhoneNumber,
            //    Salary = employee.Salary,
            //    IsActive = employee.IsActive,
            //    EmployeeType = employee.EmployeeType.ToString(),
            //    Gender = employee.Gender.ToString(),
            //    CreatedBy = employee.CreatedBy,
            //    LastModifiedBy = employee.LastModifiedBY,
            //    CreatedOn = employee.CreatedOn,
            //    LastModifiedOn = employee.LastModifiedOn,
            //    HiringDate = DateOnly.FromDateTime(employee.HiringDate)
            //}; 
            #endregion

            #region Auto Mapper
            //                                               Destination      Source
            return employee is null ? null : _mapper.Map<EmployeeDetailsDto>(employee);
            #endregion
        }

        public int AddEmployee(CreatedEmployeeDto dto)
        {
            //                           Destination    Source
            var employee = _mapper.Map<   Employee      >(dto);

            return _employeeRepository.Add(employee);
        }
        public int UpdateEmployee(UpdatedEmployeeDto dto)
        {
            //                             Destination    Source
            var employee = _mapper.Map<     Employee     >(dto);

            return _employeeRepository.Update(employee);
        }
        public bool DeleteEmployee(int id)
        {
            var employee = _employeeRepository.GetById(id);

            if (employee is null)
                return false;
            else
            {
                employee.IsDeleted = true;
                return _employeeRepository.Update(employee) > 0 ? true : false;
            }
        }

    }
}
