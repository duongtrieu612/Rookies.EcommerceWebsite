using CustomerSite.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CustomerSite.ViewComponents
{
    public class ProductsViewComponent : ViewComponent
    {
        private readonly IHttpClientFactory _clientFactory;
        public ProductsViewComponent(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            Product list = new Product();
            List<Product> product = new List<Product>();
            HttpClient client = _clientFactory.CreateClient();
            var response = await client.GetAsync("Products");
            var contents = await response.Content.ReadAsStringAsync();

            var products = JsonConvert.DeserializeObject<List<Product>>(contents);

            return View(products);
        }
    }

}
