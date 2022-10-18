
using CustomerSite.Interface;
using CustomerSite.Models;
using Newtonsoft.Json;

namespace CustomerSite.Services
{
    public class ProductSevice : IProductService
    {
        private readonly IHttpClientFactory _clientFactory;

        public ProductSevice(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }


        public async Task<List<Product>> GetProductAsync()
        {
            Product list = new Product();
            List<Product> product = new List<Product>();
            var HttpClient = _clientFactory.CreateClient();
            var data = await HttpClient.GetAsync("Products");
            var result = data.Content.ReadAsStringAsync().Result;
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
            List<Product> model = list.product.ToList();
            return model;
        }
    }
}
