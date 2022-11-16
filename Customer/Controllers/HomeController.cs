using Customer.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Newtonsoft.Json;
using Customer.ViewComponents;
using Customer.Interface;
using Customer.Interface;
using System.Dynamic;

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


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}