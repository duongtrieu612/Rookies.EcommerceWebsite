using Microsoft.AspNetCore.Mvc;
using CustomerSite.Models;
using CustomerSite.Services;
using System.Diagnostics;
using Newtonsoft.Json;

namespace CustomerSite.Controllers
{
    public class ProductsController : Controller
    {
		private readonly IProductService productService;

		public ProductsController(IProductService productService)
		{
			this.productService = productService;
		}

		public HttpClient initial()
        {
			var Client = new HttpClient();
			Client.BaseAddress = new Uri("https://localhost:7067");
			return Client;
        }
		
		public async Task<IActionResult> GetProducts()
		{
			Product list = new Product();
			List<Product> product = new List<Product>();
			HttpClient client = initial();
			HttpResponseMessage res = await client.GetAsync("api/Products");
			if(res.IsSuccessStatusCode)
            {
				var result = res.Content.ReadAsStringAsync().Result;
				product = JsonConvert.DeserializeObject<List<Product>>(result);
				foreach(var item in product)
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
	}
}
