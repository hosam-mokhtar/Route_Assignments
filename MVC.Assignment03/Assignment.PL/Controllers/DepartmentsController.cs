using Assignment.BLL.Services;
using Microsoft.AspNetCore.Mvc;

namespace Assignment.PL.Controllers
{
    public class DepartmentsController(IDepartmentService _departmentService) : Controller
    {

        //Get BaseURL/Departments/Index
        [HttpGet]
        public IActionResult Index()        
        {
            var department = _departmentService.GetAllDepartments();
            return View(department);
        }
    }
}

 