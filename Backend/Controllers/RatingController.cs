using AutoMapper;
using Backend.Data;
using Backend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shared;
using Shared.ViewModels;
using System.Diagnostics;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RatingController : Controller
    {
        private readonly MyDBContext _context;
        private readonly IMapper _mapper;
        public RatingController(MyDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet("{id:int}")]
        public IActionResult GetRatingById(int id)
        {
            var data = _context.Ratings.Where(x => x.ProductId == id);
            return Json(data);
        }

        [HttpPost]
        public IActionResult AddRating(RatingViewModel ratingViewModel)
        {
            ratingViewModel.DateComment = DateTime.Now;
            var data = _mapper.Map<Rating>(ratingViewModel);
            _context.Ratings.Add(data);
            _context.SaveChanges();
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteComment(int id)
        {
            _context.Ratings.Remove(_context.Ratings.FirstOrDefault(x => x.Id == id));
            _context.SaveChanges();
            return Ok();
        }
    }
}
