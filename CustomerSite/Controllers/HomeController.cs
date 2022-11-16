using CustomerSite.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Newtonsoft.Json;
using CustomerSite.ViewComponents;
using CustomerSite.Interface;
using System.Dynamic;
using Shared.ViewModels;

namespace CustomerSite.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        //test
        //private readonly IHttpClientFactory _clientFactory;
        //public HomeController(IHttpClientFactory clientFactory)
        //{
        //    _clientFactory = clientFactory;
        //}
        //public HttpClient initial()
        //{
        //    var Client = new HttpClient();
        //    Client.BaseAddress = new Uri("https://localhost:7067");
        //    return Client;
        //}
        private readonly IProductService productService;
        private readonly ICategoryService categoryService;
        private readonly IRatingService ratingService;

        public HomeController(IProductService productService, ICategoryService categoryService, IRatingService ratingService)
        {
            this.productService = productService;
            this.categoryService = categoryService;
            this.ratingService = ratingService;

        }
        public async Task<IActionResult> Index()
        {

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public async Task<IActionResult> Detail(int id)
        {
            var product = await productService.GetProductsId(id);
            var rating = await ratingService.GetRatingById(id);
            dynamic mymodel = new ExpandoObject();
            mymodel.Product = product;
            mymodel.Rating = rating;
            
            //Count Comment
            ViewBag.Count = mymodel.Rating.Count;

            var ratingSum = rating.Sum(d => d.RatingStar);
            ViewBag.RatingSum = ratingSum;

            return View(mymodel);
        }
        public async Task<IActionResult> Search(string searchString)
        {
            var product = await productService.SearchProduct(searchString);
            ViewData["keyWord"] = searchString;
            return View(product);
        }

        public async Task<IActionResult> Category(int id)
        {
            var product = await categoryService.GetCategoryId(id);
            return View(product);
        }


        public async Task<IActionResult> AddRating(RatingViewModel ratingViewModel)
        {
            var product = await ratingService.AddRating(ratingViewModel);
            return RedirectToAction("Detail", "Home", new { id = ratingViewModel.ProductId});
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}