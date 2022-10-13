using Backend.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
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
            return Ok(dsProduct ?? new List<Product>());
        }

    }
}
