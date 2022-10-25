using CustomerSite.Interface;
using CustomerSite.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CustomerSite.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IHttpClientFactory _clientFactory;
        public CategoryService(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }
        public async Task<List<Category>> GetAllCategory()
        {
            Category list = new Category();
            List<Category> categories = new List<Category>();
            HttpClient client = _clientFactory.CreateClient();
            var response = await client.GetAsync("Category");
            var contents = await response.Content.ReadAsStringAsync();

            var data = JsonConvert.DeserializeObject<List<Category>>(contents);

            return data;
        }

        public async Task<List<Product>> GetCategoryId(int id)
        {
            Product list = new Product();
            List<Product> products = new List<Product>();
            HttpClient client = _clientFactory.CreateClient();
            var response = await client.GetAsync($"Category/{id}");
            var contents = await response.Content.ReadAsStringAsync();

            var data = JsonConvert.DeserializeObject<List<Product>>(contents);

            return data;
        }
    }
}
