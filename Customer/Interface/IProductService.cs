using Customer.Models;

namespace Customer.Interface
{
    public interface IProductService
    {
        Task<List<Product>> GetAllProductsAsync();

        Task<Product> GetProductsId(int id);
        Task<List<Product>> SearchProduct(string searchString);
    }
}
