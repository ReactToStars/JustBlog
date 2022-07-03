using FA.JustBlog.ViewModels.Categories;

namespace FA.JustBlog.Service.IServices
{
    public interface ICategoryService : IBaseService<CategoryVM>
    {
        ResponseResult<CategoryVM> GetDetails(int id);
    }
}
