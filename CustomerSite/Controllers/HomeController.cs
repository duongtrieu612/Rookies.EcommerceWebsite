using CustomerSite.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Newtonsoft.Json;

namespace CustomerSite.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        public HttpClient initial()
        {
            var Client = new HttpClient();
            Client.BaseAddress = new Uri("https://localhost:7067");
            return Client;
        }
        public async Task<IActionResult> Index()
        {

            Product list = new Product();
            List<Product> product = new List<Product>();
            HttpClient client = initial();
            HttpResponseMessage res = await client.GetAsync("api/Products");
            if (res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                product = JsonConvert.DeserializeObject<List<Product>>(result);
                foreach (var item in product)
                {
                    list.product.Add(new Product
                    {
                        Id = item.Id,
                        Name = item.Name,
                        SoLuong = item.SoLuong,
                    });
                }
            }
            List<Product> model = list.product.ToList();
            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}