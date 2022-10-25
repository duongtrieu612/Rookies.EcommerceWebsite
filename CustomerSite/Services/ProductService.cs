
using CustomerSite.Interface;
using CustomerSite.Models;
using Newtonsoft.Json;

namespace CustomerSite.Services
{
    public class ProductService : IProductService
    {
        private readonly IHttpClientFactory _clientFactory;
        public ProductService(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }
        public async Task<List<Product>> GetAllProductsAsync()
        {
            Product list = new Product();
            List<Product> product = new List<Product>();
            HttpClient client = _clientFactory.CreateClient();
            var response = await client.GetAsync("Products");
            var contents = await response.Content.ReadAsStringAsync();

            var data = JsonConvert.DeserializeObject<List<Product>>(contents);

            return data;
        }
        public async Task<Product> GetProductsId(int id)
        {
            Product list = new Product();
            List<Product> product = new List<Product>();
            HttpClient client = _clientFactory.CreateClient();
            var response = await client.GetAsync($"Products/{id}");
            var contents = await response.Content.ReadAsStringAsync();

            var data = JsonConvert.DeserializeObject<Product>(contents);

            return data;
        }
        public async Task<List<Product>> SearchProduct(string searchString)
        {
            Product list = new Product();
            List<Product> product = new List<Product>();
            HttpClient client = _clientFactory.CreateClient();
            var response = await client.GetAsync($"Products/{searchString}");
            var contents = await response.Content.ReadAsStringAsync();

            var data = JsonConvert.DeserializeObject<List<Product>>(contents);

            return data;
        }
    }
}
