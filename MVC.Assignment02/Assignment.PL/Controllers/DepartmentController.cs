using Assignment.BLL;
namespace Assignment.PL.Controllers
{
    public class DepartmentController
    {
        //DepartmentService departmentService used A Cross All Actions
        //EmployeeService --> Assign Manager : This Service needed Only for One Action
        public DepartmentController(DepartmentService departmentService) // Call Service Department Service
        {
            
        } //Ask CLR to create object from DepartmentService
    }
}
