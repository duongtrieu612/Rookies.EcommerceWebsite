using Customer.Models;

namespace Customer.Interface
{
    public interface ICategoryService
    {
        Task<List<Category>> GetAllCategory();

        Task<List<Product>> GetCategoryId(int id);
    }
}
