using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment.BLL.DTOs.DepartmentDTOs;
using Assignment.BLL.DTOs.EmployeeDTOs;

namespace Assignment.BLL.Services.Interfaces
{
    public interface IEmployeeService
    {
        IEnumerable<EmployeeDto> GetAllEmployees(bool withTracking = false);
        EmployeeDetailsDto? GetEmployeeById(int id);
        int AddEmployee(CreatedEmployeeDto dto);
        int UpdateEmployee(UpdatedEmployeeDto dto);
        bool DeleteEmployee(int id);
    }
}
