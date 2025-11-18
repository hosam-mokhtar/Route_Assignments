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
            //override Key
            //ViewData["Msg"] = "Hello From View Data";
            //ViewBag.Msg = "Hello From View Bag";

            //ViewData["Msg01"] = "Hello From View Data";
            //ViewBag.Msg02 = "Hello From View Bag";

            ViewData["Department01"] = new DepartmentDto() { Name = "Test ViewData" };
            ViewBag.Department02 = new DepartmentDto() { Name = "Test ViewBag" };



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
        [ValidateAntiForgeryToken]
        public IActionResult Create(/*CreatedDepartmentDto deptDto*/DepartmentViewModel deptViewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var deptDto = new CreatedDepartmentDto()
                    {
                        Code = deptViewModel.Code,
                        Name = deptViewModel.Name,
                        Description = deptViewModel.Description,
                        DateOfCreation = deptViewModel.DateOfCreation
                    };

                    int res = _departmentService.AddDepartment(deptDto);
                    //if (res > 0)
                    //    return RedirectToAction(nameof(Index));
                    //else 
                    //{
                    //    ModelState.AddModelError(string.Empty, "Department can't be Added");
                    //    return View(deptDto);
                    //}

                    string msg;

                    if (res > 0)
                        msg = $"Department {deptViewModel.Name} Is Created Successfully";
                    else
                        msg = $"Department {deptViewModel.Name} Is Not Created";

                    TempData["Message"] = msg;
                    return RedirectToAction(nameof(Index));

                }
                catch (Exception ex)
                {
                    //Log Exception

                    if (_environment.IsDevelopment())
                    {
                        // 1) Development => Log Error in Console And Return The Same View with Error Message

                        ModelState.AddModelError(string.Empty, ex.Message);
                        return View(deptViewModel);

                    }
                    else
                    {
                        // 2) Deployment => Log Error in File | Table And Return The Same View with Error Message
                       
                        _logger.LogError(ex.Message);
                        return View(deptViewModel);
                    }
                }
            }

            return View(deptViewModel);        // if user add wrong or empty data
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
            var deptViewModel = new DepartmentViewModel()
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
        public IActionResult Edit([FromRoute]int id, DepartmentViewModel viewModel)
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
