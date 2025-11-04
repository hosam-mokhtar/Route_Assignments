using Assignment.BLL.DTOs.DepartmentDTOs;
using Assignment.BLL.DTOs.EmployeeDTOs;
using Assignment.BLL.Services.Classes;
using Assignment.BLL.Services.Interfaces;
using Assignment.DAL.Models.EmployeeModel;
using Assignment.DAL.Models.Shared;
using Assignment.PL.ViewModels.DepartmentViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Assignment.PL.Controllers
{
    public class EmployeesController(IEmployeeService _employeeService, 
                                     IWebHostEnvironment _environment) : Controller
    {

        #region Index
        public IActionResult Index()
        {
            var employees = _employeeService.GetAllEmployees();
            return View(employees);
        }

        #endregion

        #region Create

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Create(CreatedEmployeeDto dto/*, [FromServices] IWebHostEnvironment _environment*/)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    int res = _employeeService.AddEmployee(dto);
                    if (res > 0)
                        return RedirectToAction(nameof(Index));
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Employee can't be Added");
                        return View(dto);
                    }
                }
                catch (Exception ex)
                {
                    //Log Exception

                    if (_environment.IsDevelopment())
                    {
                        // 1) Development => Log Error in Console And Return The Same View with Error Message

                        ModelState.AddModelError(string.Empty, ex.Message);
                        return View(dto);

                    }
                    else
                    {
                        // 2) Deployment => Log Error in File | Table And Return The Same View with Error Message
                        //_logger.LogError(ex.Message);

                        return View(dto);
                    }
                }
            }

            return View(dto);        // if user add wrong or empty data
        }
        #endregion


        #region Details

        [HttpGet]
        //Nullable (id) because if you enter id from browser  
        public IActionResult Details(int? id)
        {
            if (!id.HasValue)
                return BadRequest();  //400

            var emp = _employeeService.GetEmployeeById(id.Value);

            if (emp is null)
                return NotFound();    //404

            return View(emp);
        }

        #endregion


        #region Edit

        [HttpGet]
        //Nullable (id) because if you enter id from browser  
        public IActionResult Edit(int? id)
        {
            if (!id.HasValue)
                return BadRequest();

            var emp = _employeeService.GetEmployeeById(id.Value);

            if (emp is null)
                return NotFound();

            //return View(emp);                    // Error => because GetEmployeeById(id.Value) return EmployeeDetailsDto
            //this EmployeeDetailsDto not valid in View(Edit) because View(Edit) Bind on UpdatedEmployeeDto

            // Solution => bind on  ViewModel
            var dto = new UpdatedEmployeeDto()
            {
                Id = emp.Id,
                Name = emp.Name,
                Age = emp.Age,
                Address = emp.Address,
                Email = emp.Email,
                PhoneNumber = emp.PhoneNumber,
                Salary = emp.Salary,
                HiringDate = emp.HiringDate,
                IsActive    = emp.IsActive,
                EmployeeType     = Enum.Parse<EmployeeType>(emp.EmployeeType),
                Gender           = Enum.Parse<Gender>(emp.Gender)
            };


            return View(dto);
        }

        [HttpPost]
        public IActionResult Edit([FromRoute] int id, UpdatedEmployeeDto dto)
        {
            if(id != dto.Id)
                return BadRequest();


            if (!ModelState.IsValid)
                return View(dto);
            try
            {
                var res = _employeeService.UpdateEmployee(dto);

                if (res > 0)
                    return RedirectToAction(nameof(Index));

                return View(dto);

            }
            catch (Exception ex)
            {
                //Log Exception

                if (_environment.IsDevelopment())
                {
                    // 1) Development => Log Error in Console And Return The Same View with Error Message

                    ModelState.AddModelError(string.Empty, ex.Message);
                    return View(dto);

                }
                else
                {
                    // 2) Deployment => Log Error in File | Table And Return The Same View with Error Message
                    //_logger.LogError(ex.Message);
                    return View(dto);
                }
            }

        }

        #endregion

        #region Delete


        [HttpPost]
        //Non-Nullable id => because  => <form method = "post" asp-controller="Departments" asp-action="Delete" asp-route-id="@Model.Id">
        public IActionResult Delete(int id)
        {
            if (id == 0)
                return BadRequest();
            try
            {
                bool isDeleted = _employeeService.DeleteEmployee(id);
                if (isDeleted)
                    return RedirectToAction(nameof(Index));
                else
                    ModelState.AddModelError(string.Empty, "Employee can't Be Deleted");

                return RedirectToAction(nameof(Delete), new { id });

            }
            catch (Exception ex)
            {
                //Log Exception

                if (_environment.IsDevelopment())
                {
                    // 1) Development => Log Error in Console And Return The Same View with Error Message

                    ModelState.AddModelError(string.Empty, ex.Message);
                    return RedirectToAction(nameof(Index));

                }
                else
                {
                    // 2) Deployment => Log Error in File | Table And Return The Same View with Error Message
                    //_logger.LogError(ex.Message);

                    return View("ErrorView", ex);
                }
            }

        }
        #endregion

    }
}
