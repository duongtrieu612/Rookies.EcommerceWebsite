using AutoMapper;
using Backend.Data;
using Backend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shared;
using System.Diagnostics;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : Controller
    {
        private readonly MyDBContext _context;
        private readonly IMapper _mapper;
        public ProductsController(MyDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
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

        [HttpPost]
        public IActionResult CreateProduct(ProductViewModel productViewModel)
        {
            var dsProduct = _mapper.Map<Product>(productViewModel);
            _context.Products.Add(dsProduct);
            _context.SaveChanges();
            return Ok();

        }


        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            _context.Products.Remove(_context.Products.FirstOrDefault(x => x.Id == id));
            _context.SaveChanges();
            return Ok();

        }


    }
}
