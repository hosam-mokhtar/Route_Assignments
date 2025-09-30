using Microsoft.AspNetCore.Mvc;
using MVC.Models;

namespace MVC.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            //return View();                             //Return View with The Same Name of Action {Index}
            //return View("Index");                      //Return View with The Specific Name
            //return View(nameof(HomeController.Index)); //Return View with The Specific Name
            //return View("Index",new Movie());          //Return View with The Specific Name And Model
            //return View(new Movie());                  //Return View with The Model

            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult ContactUs()
        {
            return View();
        }
        public IActionResult AboutUs()
        {
            return View();
        }

    }
}
