using CustomerSite.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Newtonsoft.Json;
using CustomerSite.ViewComponents;
using CustomerSite.Interface;

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

        public HomeController(IProductService productService)
        {
            this.productService = productService;
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
            return View(product);
        }
        public async Task<IActionResult> Search(string searchString)
        {
            var product = await productService.SearchProduct(searchString);
            ViewData["keyWord"] = searchString;
            return View(product);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}