using System;
using Microsoft.AspNetCore.Mvc;
using MVC.Models;

namespace MVC.Controllers
{
    public class MoviesController : Controller
    {
        //Wrong Logic Code
        //public string Index(int? id, string name)
        //{
        //    return $"id : {id}, name : {name}";
        //}

        public string Index(/*int? id*/)
        {
            //return $"id : {id}";
            return "Hello From Index";
        }

        #region HttpGet

        /*

//Get BaseUrl/Movies/GetMovie/id?name=filename     
//Get BaseUrl/Movies/GetMovie?id=10&name=filename
[HttpGet]                            //Default always Get but to ensure put attribute[HttpGet]
public ContentResult GetMovie(int? id, string name)
{
    //ContentResult result = new ContentResult();
    ////result.Content = $"Movie :: {id}, {name}";
    //result.Content = $"Movie :: {id} </br> {name}";
    //result.ContentType = "text/html";
    //result.StatusCode = 700;

    //return result;
    //return Content($"Movie :: {id}, {name}");
    //or
    return Content($"Movie :: {id} </br> {name}","text/html");
}
*/


        //Get BaseUrl/Movies/GetMovie?id=10&name=filename
        [HttpGet]
        public IActionResult /* or ActionResult */ GetMovie(int? id, string name)
        {
            if (id == 0)
                return /*new BadRequestResult() or */ BadRequest();
            else if (id < 10)
                return /*new NotFoundResult() or */ NotFound();
            else
                return Content($"Movie wth Name: {name} </br> Id: {id}", "text/html");

        }

        //Get BaseUrl/Movies/TestRedirectToAction
        [HttpGet]
        public IActionResult TestRedirectToAction()
        {

            #region  RedirectToAction
            //Amazon Web Application
            //return Redirect("https://www.amazon.eg/?&tag=egtxabkgode-21&ref=pd_sl_7p2aq4fe2v_e&adgrpid=152488092398&hvpone=&hvptwo=&hvadid=666798652278&hvpos=&hvnetw=g&hvrand=6686104484482084494&hvqmt=e&hvdev=c&hvdvcmdl=&hvlocint=&hvlocphy=9112376&hvtargid=kwd-10573980&hydadcr=334_2589534&language=en_AE");
            //return Redirect("https://localhost:7284/movies/GetMovie?id=15&name=text");          //Fixed Route 
            //return RedirectToAction(/*"GetMovie"*/ nameof(MoviesController.GetMovie));          //In The Same Controller
            return RedirectToAction("GetMovie", "Movies");                                         //Different Controller
            //return RedirectToAction("GetMovie","Movies",new { id = 15, name = "tessssst"});     //Different Controller
            #endregion

            #region  RedirectToRoute
            //RedirectToRoute
            //return RedirectToRoute("default");
            //return RedirectToRoute("default", new {controller = "Movies",
            //                                       action = "GetMovie",
            //                                       id = 15,
            //                                       name = "tessssst" });
            #endregion
        }

        [HttpGet]
        //Complex Data
        public IActionResult AddMovieGet1(Movie movie)
        {
            return Content($"Movie: {movie.Title}, Id is {movie.Id}");
        }

        [HttpGet]
        //Mixed Data Parameters
        public IActionResult AddMovieGet2(int Id, Movie movie, string Title)
        {
            //if (movie is null)
            //    return BadRequest();

            return Content($"Movie: {movie.Title}, Id is {movie.Id}");
        }

        [HttpGet]
        //Collection Data Parameters
        public IActionResult AddMovieGet3(int[] arr)
        {
            return Content($"{arr[0]}, {arr[1]}");
        }

        [HttpGet]
        //Mixed Data Parameters (Any Match)
        public IActionResult AddMovieGet4(int Id, Movie movie, string Title, int[] arr)
        {
            return Content($"{Id},{Title},{movie.Id},{movie.Title},{arr[0]}, {arr[1]}");
        }

        #endregion

        #region HttpPost
        [HttpPost]
        //simple data
        public IActionResult TestModelBinding([FromRoute] int id, [FromQuery] string name)
        {
            return Content($"Hello {name} your Id is {id}");
        }

        [HttpPost]
        //Complex Object
        public IActionResult AddMovie([FromBody] Movie movie)
        { 
            if(movie is null)  
                return BadRequest();

            return Content($"Movie: {movie.Title}, Id is {movie.Id}");
        }

        [HttpPost]
        //Header must be take Simple Data
        public IActionResult AddMovieFromHeader([FromHeader] int id, [FromHeader] string name)
        {
            return Content($"Movie: {name}, Id is {id}");
        }

        #endregion


    }
}
