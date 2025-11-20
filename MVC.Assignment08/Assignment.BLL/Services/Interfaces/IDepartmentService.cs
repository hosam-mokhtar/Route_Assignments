using Assignment.BLL.DTOs.DepartmentDTOs;

namespace Assignment.BLL.Services.Interfaces
{
    public interface IDepartmentService
    {
        IEnumerable<DepartmentDto> GetAllDepartments();
        DepartmentDetailsDto? GetDepartmentById(int id);
        int AddDepartment(CreatedDepartmentDto departmentDto);
        int UpdateDepartment(UpdateDepartmentDto departmentDto);
        bool DeleteDepartment(int id);
    }
}