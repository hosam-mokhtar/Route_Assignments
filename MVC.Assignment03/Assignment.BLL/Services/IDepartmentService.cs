using Assignment.BLL.DTOs;

namespace Assignment.BLL.Services
{
    public interface IDepartmentService
    {
        int AddDepartment(CreeatedDepartmentDto departmentDto);
        bool DeleteDepartment(int id);
        IEnumerable<DepartmentDto> GetAllDepartments();
        DepartmentDetailsDto? GetById(int id);
        int UpdateDepartment(UpdateDepartmentDto departmentDto);
    }
}