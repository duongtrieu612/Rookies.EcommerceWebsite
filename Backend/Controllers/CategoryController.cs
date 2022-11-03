using Backend.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Newtonsoft.Json;
using Backend.Models;
using Shared;
using AutoMapper;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : Controller
    {
        private readonly MyDBContext _context;
        private readonly IMapper _mapper;
        public CategoryController(MyDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetAllCategory()
        {
            var dsCategory = _context.Categories.ToList();
            return Json(dsCategory);
        }
        [HttpGet("{id}")]
        public IActionResult GetCategoryById(int id)
        {
            var dsCategory = _context.Products.Where(x => x.Category.Id == id).ToList();
            return Json(dsCategory);
        }

        [HttpPost]
        public IActionResult CreateCategory(CategoryViewModel categoryViewModel)
        {
            var dsCategory = _mapper.Map<Category>(categoryViewModel);
            _context.Categories.Add(dsCategory);
            _context.SaveChanges();
            return Ok();

        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCategory(int id)
        {
            _context.Categories.Remove(_context.Categories.FirstOrDefault(x => x.Id == id));
            _context.SaveChanges();
            return Ok();

        }



        
    }
}
