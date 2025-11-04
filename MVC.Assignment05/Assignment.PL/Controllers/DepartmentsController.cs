using Assignment.BLL.DTOs;
using Assignment.BLL.DTOs.DepartmentDTOs;
using Assignment.BLL.Services.Interfaces;
using Assignment.PL.ViewModels.DepartmentViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Assignment.PL.Controllers
{
    public class DepartmentsController(IDepartmentService _departmentService,
        ILogger<HomeController> _logger,
        IWebHostEnvironment _environment) : Controller
    {

        #region Index
        //Get BaseURL/Departments/Index
        [HttpGet]
        public IActionResult Index()
        {
            var department = _departmentService.GetAllDepartments();
            return View(department);
        }

        #endregion

        #region Create

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreatedDepartmentDto dto)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    int res = _departmentService.AddDepartment(dto);
                    if (res > 0)
                        return RedirectToAction(nameof(Index));
                    else 
                    {
                        ModelState.AddModelError(string.Empty, "Department can't be Added");
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
                       
                        _logger.LogError(ex.Message);
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
            
            var department = _departmentService.GetDepartmentById(id.Value);

            if (department is null)
                return NotFound();    //404

            return View(department);           
        }

        #endregion

        #region Edit

        [HttpGet]
        //Nullable (id) because if you enter id from browser  
        public IActionResult Edit(int? id) 
        {
            if (!id.HasValue)
                return BadRequest();

            var dept =_departmentService.GetDepartmentById(id.Value);

            if (dept is null)
                return NotFound();

            //return View(dept);                    // Error => because GetDepartmentById(id.Value) return DepartmentDetailsDto
                                                               //this DepartmentDetailsDto not valid in View(Edit) because View(Edit) Bind on UpdateDepartmentDto

            // Solution => bind on  ViewModel
            var deptViewModel = new DepartmentEditViewModel()
            {
                //Id = id.Value,
                Code = dept.Code,
                Name = dept.Name,
                Description = dept.Description,
                DateOfCreation = dept.DateOfCreation
            };

            return View(deptViewModel);
        }

        [HttpPost]
        public IActionResult Edit([FromRoute]int id, DepartmentEditViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return View(viewModel);
            try
            {
                var updateDeptDto = new UpdateDepartmentDto()
                {
                    //Id = viewModel.Id,
                    Id = id,
                    Code = viewModel.Code,
                    Name = viewModel.Name,
                    Description = viewModel.Description,
                    DateOfCreation = viewModel.DateOfCreation
                };

                var res = _departmentService.UpdateDepartment(updateDeptDto);

                if (res > 0)
                    return RedirectToAction(nameof(Index));

                return View(viewModel);

            }
            catch (Exception ex) 
            {
                //Log Exception

                if (_environment.IsDevelopment())
                {
                    // 1) Development => Log Error in Console And Return The Same View with Error Message

                    ModelState.AddModelError(string.Empty, ex.Message);
                    return View(viewModel);

                }
                else
                {
                    // 2) Deployment => Log Error in File | Table And Return The Same View with Error Message

                    _logger.LogError(ex.Message);
                    return View(viewModel);
                }
            }

        }

        #endregion

        #region Delete

        //[HttpGet]
        //public IActionResult Delete(int? id)
        //{
        //    if (!id.HasValue)
        //        return BadRequest();

        //    var dept = _departmentService.GetDepartmentById(id.Value);

        //    if (dept is null)
        //        return NotFound();

        //    return View(dept);
        //}

        [HttpPost]
        //Non-Nullable id => because  => <form method = "post" asp-controller="Departments" asp-action="Delete" asp-route-id="@Model.Id">
        public IActionResult Delete(int id)
        {
            if (id == 0)
                return BadRequest();
            try
            {
                bool isDeleted = _departmentService.DeleteDepartment(id);
                if (isDeleted)
                    return RedirectToAction(nameof(Index));
                else
                    ModelState.AddModelError(string.Empty, "Department can't Be Deleted");

                return RedirectToAction(nameof(Delete), new {id});
                    
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
                    return View("ErrorView",ex);
                }
            }
      
        }

        #endregion
    }
}
