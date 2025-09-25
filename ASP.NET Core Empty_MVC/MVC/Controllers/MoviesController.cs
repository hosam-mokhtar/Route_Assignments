using Microsoft.AspNetCore.Mvc;

namespace MVC.Controllers
{
    public class MoviesController : Controller
    {
        public string index(int? id)
        {
            return $"id : {id}";
        }

        //Wrong Logic Code
        //public string Index(int? id, string name)
        //{
        //    return $"id : {id}, name : {name}";
        //}
    }
}
