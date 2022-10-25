using CustomerSite.Models;

namespace CustomerSite.Interface
{
    public interface ICategoryService
    {
        Task<List<Category>> GetAllCategory();

        Task<List<Product>> GetCategoryId(int id);
    }
}
