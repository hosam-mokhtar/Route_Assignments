using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Talabat.models;

namespace Talabat.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase  //BaseUrl/api/Product
    {
        //Static Segment
        //[HttpGet("id")]    // GET  :    BaseUrl/api/Product?id=6
        //Dynamic Segment
        [HttpGet("{id}")]  // GET  :    BaseUrl/api/Product?id=6
        public ActionResult<Product> Get(int id)
        {
            return new Product() { Id = id };
        }

        [HttpGet]  // GET  :    BaseUrl/api/Product
        public ActionResult<Product> GetAll()
        {
            return new Product() { Id = 20 };
        }

        [HttpPost]  // POST  :    BaseUrl/api/Product
        public ActionResult<Product> AddProduct(Product product)
        {
            return new Product();
        }
         
        [HttpPost("brand")]  // POST  :    BaseUrl/api/Product
        public ActionResult<Product> AddBrand(Product product)
        {
            return new Product();
        }


        [HttpPut]  // PUT  :    BaseUrl/api/Product
        public ActionResult<Product> UpdateProduct(Product product)
        {
            return new Product();
        }


        [HttpDelete]  // DELETE  :    BaseUrl/api/Product
        public ActionResult<Product> DeleteProduct(int id)
        {
            return new Product() { Id = id};
        }
    }
}
