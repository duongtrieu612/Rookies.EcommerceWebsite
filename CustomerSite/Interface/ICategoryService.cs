using Shared;

namespace CustomerSite.Interface
{
    public interface ICategoryService
    {
        Task<List<CategoryViewModel>> GetAllCategory();

        Task<List<ProductViewModel>> GetCategoryId(int id);
    }
}
