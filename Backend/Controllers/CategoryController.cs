﻿using Backend.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Newtonsoft.Json;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : Controller
    {
        private readonly MyDBContext _context;
        public CategoryController(MyDBContext context)
        {
            _context = context;
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
    }
}
