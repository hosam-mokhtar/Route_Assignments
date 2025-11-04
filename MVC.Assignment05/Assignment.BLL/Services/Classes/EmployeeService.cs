using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment.BLL.DTOs.EmployeeDTOs;
using Assignment.BLL.Services.Interfaces;
using Assignment.DAL.Models.EmployeeModel;
using Assignment.DAL.Repositories.Interfaces;
using AutoMapper;

namespace Assignment.BLL.Services.Classes
{
    public class EmployeeService(IEmployeeRepository _employeeRepository, IMapper _mapper) : IEmployeeService
    {
        public IEnumerable<EmployeeDto> GetAllEmployees(bool withTracking = false)
        {
            var employees = _employeeRepository.GetAll();

            #region Manual Mapping
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

            //                                            Source                Destination    Source
            //var employeesDto = _mapper.Map<IEnumerable<Employee>, IEnumerable<EmployeeDto>>(employees);
            //return employeesDto;

            //or Syntax

            //                              Destination    Source
            return _mapper.Map<IEnumerable<EmployeeDto>>(employees);

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
