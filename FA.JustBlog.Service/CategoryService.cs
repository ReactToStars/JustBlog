using FA.JustBlog.Core.Infrastructures;
using FA.JustBlog.Core.Models;
using FA.JustBlog.Service.IServices;
using FA.JustBlog.ViewModels.Categories;

namespace FA.JustBlog.Service
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoryService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public ResponseResult<CategoryVM> Add(CategoryVM entity)
        {
            try
            {
                Category category = new Category();
                category.CategoryName = entity.CategoryName;
                category.Description = entity.Description;
                category.UrlSlug = entity.UrlSlug;
                _unitOfWork.CategoryRepository.Add(category);
                _unitOfWork.SaveChanges();
                return new ResponseResult<CategoryVM>();
            }
            catch (Exception ex)
            {
                return new ResponseResult<CategoryVM>("Error: " + ex.Message);
            }
        }

        public ResponseResult<CategoryVM> Delete(int id)
        {
            try
            {
                _unitOfWork.CategoryRepository.Delete(id);
                _unitOfWork.SaveChanges();
                return new ResponseResult<CategoryVM>();
            }
            catch (Exception ex)
            {
                return new ResponseResult<CategoryVM>("Error: " + ex.Message);
            }
        }

        public ResponseResult<CategoryVM> Delete(CategoryVM entity)
        {
            try
            {
                Category category = new();
                category.CategoryId = entity.CategoryId;
                category.CategoryName = entity.CategoryName;
                category.UrlSlug = entity?.UrlSlug;
                category.Description = entity.Description;
                _unitOfWork.CategoryRepository.Delete(category);
                _unitOfWork.SaveChanges();
                return new ResponseResult<CategoryVM>();
            }
            catch (Exception ex)
            {
                return new ResponseResult<CategoryVM>("Error" + ex.Message);
            }
        }

        public ResponseResult<CategoryVM> Find(int id)
        {
            try
            {
                var category = _unitOfWork.CategoryRepository.Find(id);
                if (category != null)
                {
                    CategoryVM categoryVM = new CategoryVM();
                    categoryVM.CategoryId = category.CategoryId;
                    categoryVM.CategoryName = category.CategoryName;
                    categoryVM.UrlSlug = category.UrlSlug;
                    categoryVM.Description = category.Description;
                    ResponseResult<CategoryVM> responseResult = new ResponseResult<CategoryVM>();
                    responseResult.Data = categoryVM;
                    return responseResult;
                }
                return new ResponseResult<CategoryVM>("Khong tim thay");
            }
            catch (Exception ex)
            {
                return new ResponseResult<CategoryVM>("Error: " + ex.Message);
            }
        }

        public ResponseResult<IList<CategoryVM>> GetAll()
        {
            try
            {
                ResponseResult<IList<CategoryVM>> responseResult = new();
                var categories = _unitOfWork.CategoryRepository.GetAll();
                IList<CategoryVM> categoryVMs = new List<CategoryVM>();
                foreach (var category in categories)
                {
                    categoryVMs.Add(new CategoryVM()
                    {
                        CategoryId = category.CategoryId,
                        CategoryName = category.CategoryName,
                        UrlSlug = category.UrlSlug,
                        Description = category.Description,
                    });
                }
                responseResult.Data = categoryVMs;
                return responseResult;
            }
            catch (Exception ex)
            {
                return new ResponseResult<IList<CategoryVM>>("Error: " + ex.Message);
            }
        }

        public ResponseResult<CategoryVM> GetDetails(int id)
        {
            try
            {
                Category categoryExisting = _unitOfWork.CategoryRepository.Find(id);
                CategoryVM categoryVM = new CategoryVM()
                {
                    CategoryId = categoryExisting.CategoryId,
                    CategoryName = categoryExisting.CategoryName,
                    UrlSlug = categoryExisting?.UrlSlug,
                    Description = categoryExisting.Description,
                };
                ResponseResult<CategoryVM> responseResult = new ResponseResult<CategoryVM>();
                responseResult.Data = categoryVM;
                return responseResult;
            }
            catch (Exception ex)
            {
                return new ResponseResult<CategoryVM>("Error" + ex.Message);
            }
        }

        public ResponseResult<CategoryVM> Update(CategoryVM entity)
        {
            try
            {
                var category = new Category()
                {
                    CategoryId = entity.CategoryId,
                    CategoryName = entity.CategoryName,
                    UrlSlug = entity.UrlSlug,
                    Description = entity.Description,
                };
                _unitOfWork.CategoryRepository.Update(category);
                _unitOfWork.SaveChanges();
                return new ResponseResult<CategoryVM>();
            }
            catch (Exception ex)
            {
                return new ResponseResult<CategoryVM>("Error: " + ex.Message);
            }
        }
    }
}
