using Backend.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : Controller
    {
        private readonly MyDBContext _context;

        public ProductsController(MyDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAllProduct()
        {
            var dsProduct = _context.Products.ToList();
            return Json(dsProduct); 
        }

        [HttpGet("{id:int}")]
        public IActionResult GetProductById(int id)
        {
            var dsProduct = _context.Products.SingleOrDefault(x => x.Id == id);
            return Json(dsProduct);
        }
        [HttpGet("{search}")]
        public IActionResult SearchProduct(string search)
        {
            var dsProduct = _context.Products.Where(x => x.Name.Contains($"{search}")).ToList();
            return Json(dsProduct);
        }


    }
}
