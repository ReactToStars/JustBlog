using FA.JustBlog.Core.Infrastructures;
using FA.JustBlog.Core.Models;
using FA.JustBlog.Service.IServices;
using FA.JustBlog.ViewModels.Posts;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FA.JustBlog.Service
{
    public class PostService : IPostService
    {
        private readonly IUnitOfWork _unitOfWork;

        public PostService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public ResponseResult<PostCreateVM> Add(PostCreateVM postCreateVM)
        {
            try
            {
                Post post = new Post();
                post.Title = postCreateVM.Title;
                post.ShortDescription = postCreateVM.ShortDescription;
                post.PostContent = postCreateVM.PostContent;
                post.UrlSlug = postCreateVM.UrlSlug;
                post.Published = postCreateVM.Published;
                post.CategoryId = postCreateVM.CategoryId;
                _unitOfWork.PostRepository.Add(post);
                _unitOfWork.SaveChanges();
                return new ResponseResult<PostCreateVM>();
            }
            catch (Exception ex)
            {
                return new ResponseResult<PostCreateVM>("Error: " + ex.Message);
            }
        }

        public ResponseResult<PostEditVM> Delete(int id)
        {
            try
            {
                _unitOfWork.PostRepository.Delete(id);
                _unitOfWork.SaveChanges();
                return new ResponseResult<PostEditVM>();
            }
            catch (Exception ex)
            {
                return new ResponseResult<PostEditVM>("Error: " + ex.Message);
            }
        }

        public ResponseResult<PostEditVM> Delete(PostEditVM postIndexVM)
        {
            try
            {
                Post post = new();
                post.PostId = postIndexVM.PostId;
                _unitOfWork.PostRepository.Delete(post);
                _unitOfWork.SaveChanges();
                return new ResponseResult<PostEditVM>();
            }
            catch (Exception ex)
            {
                return new ResponseResult<PostEditVM>("Error" + ex.Message);
            }
        }

        public ResponseResult<PostEditVM> Find(int id)
        {
            try
            {
                var postExisting = _unitOfWork.PostRepository.Find(id);
                if (postExisting != null)
                {
                    PostEditVM postEdit = new PostEditVM();
                    postEdit.PostId = postExisting.PostId;
                    postEdit.Title = postExisting.Title;
                    postEdit.ShortDescription = postExisting.ShortDescription;
                    postEdit.PostContent = postExisting.PostContent;
                    postEdit.UrlSlug = postExisting.UrlSlug;
                    postEdit.Published = postExisting.Published;
                    postEdit.Modified = postExisting.Modified;
                    postEdit.CategoryId = postExisting.CategoryId;
                    postEdit.CategoryName = postExisting.Category.CategoryName;
                    postEdit.CategoryList = GetListCategory();
                    ResponseResult<PostEditVM> responseResult = new ResponseResult<PostEditVM>();
                    responseResult.Data = postEdit;
                    return responseResult;
                }
                return new ResponseResult<PostEditVM>("Cannot found!");
            }
            catch (Exception ex)
            {
                return new ResponseResult<PostEditVM>("Error: " + ex.Message);
            }
        }

        public ResponseResult<IList<PostIndexVM>> GetAll()
        {
            try
            {
                ResponseResult<IList<PostIndexVM>> responseResult = new();
                var posts = _unitOfWork.PostRepository.GetAll();
                IList<PostIndexVM> postIndexVMs = new List<PostIndexVM>();
                foreach (var post in posts)
                {
                    postIndexVMs.Add(new PostIndexVM()
                    {
                        PostId = post.PostId,
                        Title = post.Title,
                        ShortDescription = post.ShortDescription,
                        UrlSlug = post.UrlSlug,
                        Published = post.Published,
                        PostedOn = post.PostedOn,
                        Modified = post.Modified,
                        ViewCount = post.ViewCount,
                        Rate = post.Rate,
                        CategoryId = post.CategoryId,
                        CategoryName = post.Category.CategoryName
                    });
                }
                responseResult.Data = postIndexVMs;
                return responseResult;
            }
            catch (Exception ex)
            {
                return new ResponseResult<IList<PostIndexVM>>("Error: " + ex.Message);
            }
        }

        public ResponseResult<PostDetailVM> GetDetail(int id)
        {
            try
            {
                var postExisting = _unitOfWork.PostRepository.Find(id);
                if (postExisting != null)
                {
                    PostDetailVM postDetail = new PostDetailVM();
                    postDetail.PostId = postExisting.PostId;
                    postDetail.Title = postExisting.Title;
                    postDetail.ShortDescription = postExisting.ShortDescription;
                    postDetail.PostContent = postExisting.PostContent;
                    postDetail.UrlSlug = postExisting.UrlSlug;
                    postDetail.Published = postExisting.Published;
                    postDetail.PostedOn = postExisting.PostedOn;
                    postDetail.Modified = postExisting.Modified;
                    postDetail.ViewCount = postExisting.ViewCount;
                    postDetail.RateCount = postExisting.RateCount;
                    postDetail.TotalRate = postExisting.TotalRate;
                    postDetail.Rate = postExisting.Rate;
                    postDetail.CategoryId = postExisting.CategoryId;
                    postDetail.CategoryName = postExisting.Category.CategoryName;
                    ResponseResult<PostDetailVM> responseResult = new ResponseResult<PostDetailVM>();
                    responseResult.Data = postDetail;
                    return responseResult;
                }
                return new ResponseResult<PostDetailVM>("Cannot found!");
            }
            catch (Exception ex)
            {
                return new ResponseResult<PostDetailVM>("Error: " + ex.Message);
            }
        }

        public ResponseResult<IList<PostIndexVM>> GetLatestPost(int size)
        {
            try
            {
                ResponseResult<IList<PostIndexVM>> responseResult = new();
                var posts = _unitOfWork.PostRepository.GetLatestPosts(size);
                IList<PostIndexVM> postIndexVMs = new List<PostIndexVM>();
                foreach (var post in posts)
                {
                    postIndexVMs.Add(new PostIndexVM()
                    {
                        PostId = post.PostId,
                        Title = post.Title,
                        ShortDescription = post.ShortDescription,
                        UrlSlug = post.UrlSlug,
                        Published = post.Published,
                        PostedOn = post.PostedOn,
                        Modified = post.Modified,
                        ViewCount = post.ViewCount,
                        Rate = post.Rate,
                        CategoryId = post.CategoryId,
                        CategoryName = post.Category.CategoryName
                    });
                }
                responseResult.Data = postIndexVMs;
                return responseResult;
            }
            catch (Exception ex)
            {
                return new ResponseResult<IList<PostIndexVM>>("Error: " + ex.Message);
            }
        }

        public ResponseResult<IList<PostIndexVM>> GetMostViewedPosts(int size)
        {
            try
            {
                ResponseResult<IList<PostIndexVM>> responseResult = new();
                var posts = _unitOfWork.PostRepository.GetMostViewedPosts(size);
                IList<PostIndexVM> postIndexVMs = new List<PostIndexVM>();
                foreach (var post in posts)
                {
                    postIndexVMs.Add(new PostIndexVM()
                    {
                        PostId = post.PostId,
                        Title = post.Title,
                        ShortDescription = post.ShortDescription,
                        UrlSlug = post.UrlSlug,
                        Published = post.Published,
                        PostedOn = post.PostedOn,
                        Modified = post.Modified,
                        ViewCount = post.ViewCount,
                        Rate = post.Rate,
                        CategoryId = post.CategoryId,
                        CategoryName = post.Category.CategoryName
                    });
                }
                responseResult.Data = postIndexVMs;
                return responseResult;
            }
            catch (Exception ex)
            {
                return new ResponseResult<IList<PostIndexVM>>("Error: " + ex.Message);
            }
        }

        public IEnumerable<SelectListItem> GetListCategory()
        {
            return _unitOfWork.CategoryRepository.GetAll().Select(
                u => new SelectListItem
                {
                    Text = u.CategoryName,
                    Value = u.CategoryId.ToString(),
                });
        }

        public ResponseResult<PostEditVM> Update(PostEditVM postEditVM)
        {
            try
            {
                var post = new Post()
                {
                    PostId = postEditVM.PostId,
                    Title = postEditVM.Title,
                    ShortDescription = postEditVM.ShortDescription,
                    PostContent = postEditVM.PostContent,
                    UrlSlug = postEditVM.UrlSlug,
                    Published = postEditVM.Published,
                    CategoryId = postEditVM.CategoryId,
                    Modified = DateTime.Now
                };
                _unitOfWork.PostRepository.Update(post);
                _unitOfWork.SaveChanges();
                return new ResponseResult<PostEditVM>();
            }
            catch (Exception ex)
            {
                return new ResponseResult<PostEditVM>("Error: " + ex.Message);
            }
        }

        public ResponseResult<IList<PostIndexVM>> GetPostsByCategoryId(int id)
        {
            try
            {
                ResponseResult<IList<PostIndexVM>> responseResult = new();
                var posts = _unitOfWork.PostRepository.GetPostsByCategoryId (id);
                IList<PostIndexVM> postIndexVMs = new List<PostIndexVM>();
                foreach (var post in posts)
                {
                    postIndexVMs.Add(new PostIndexVM()
                    {
                        PostId = post.PostId,
                        Title = post.Title,
                        ShortDescription = post.ShortDescription,
                        UrlSlug = post.UrlSlug,
                        Published = post.Published,
                        PostedOn = post.PostedOn,
                        Modified = post.Modified,
                        ViewCount = post.ViewCount,
                        Rate = post.Rate,
                        CategoryId = post.CategoryId,
                        CategoryName = post.Category.CategoryName
                    });
                }
                responseResult.Data = postIndexVMs;
                return responseResult;
            }
            catch (Exception ex)
            {
                return new ResponseResult<IList<PostIndexVM>>("Error: " + ex.Message);
            }
        }

        public ResponseResult<IList<PostIndexVM>> GetPostsByTagId(int id)
        {
            try
            {
                ResponseResult<IList<PostIndexVM>> responseResult = new();
                var posts = _unitOfWork.PostRepository.GetPostsByTagId(id);
                IList<PostIndexVM> postIndexVMs = new List<PostIndexVM>();
                foreach (var post in posts)
                {
                    postIndexVMs.Add(new PostIndexVM()
                    {
                        PostId = post.PostId,
                        Title = post.Title,
                        ShortDescription = post.ShortDescription,
                        UrlSlug = post.UrlSlug,
                        Published = post.Published,
                        PostedOn = post.PostedOn,
                        Modified = post.Modified,
                        ViewCount = post.ViewCount,
                        Rate = post.Rate,
                        CategoryId = post.CategoryId,
                        //CategoryName=post.Category.CategoryName
                    });
                }
                responseResult.Data = postIndexVMs;
                return responseResult;
            }
            catch (Exception ex)
            {
                return new ResponseResult<IList<PostIndexVM>>("Error: " + ex.Message);
            }
        }

        public ResponseResult<PostDetailVM> FindPost(int year, int month, string title)
        {
            try
            {
                var postExisting = _unitOfWork.PostRepository.FindPost(year, month, title);
                if (postExisting != null)
                {
                    PostDetailVM postDetail = new PostDetailVM();
                    postDetail.PostId = postExisting.PostId;
                    postDetail.Title = postExisting.Title;
                    postDetail.ShortDescription = postExisting.ShortDescription;
                    postDetail.PostContent = postExisting.PostContent;
                    postDetail.UrlSlug = postExisting.UrlSlug;
                    postDetail.Published = postExisting.Published;
                    postDetail.PostedOn = postExisting.PostedOn;
                    postDetail.Modified = postExisting.Modified;
                    postDetail.ViewCount = postExisting.ViewCount;
                    postDetail.RateCount = postExisting.RateCount;
                    postDetail.TotalRate = postExisting.TotalRate;
                    postDetail.Rate = postExisting.Rate;
                    postDetail.CategoryName = postExisting.Category.CategoryName;
                    ResponseResult<PostDetailVM> responseResult = new ResponseResult<PostDetailVM>();
                    responseResult.Data = postDetail;
                    return responseResult;
                }
                return new ResponseResult<PostDetailVM>("Cannot found!");
            }
            catch (Exception ex)
            {
                return new ResponseResult<PostDetailVM>("Error: " + ex.Message);
            }
        }

        public ResponseResult<IList<PostIndexVM>> GetInterestingPosts(int size)
        {
            try
            {
                ResponseResult<IList<PostIndexVM>> responseResult = new();
                var posts = _unitOfWork.PostRepository.GetHighestPosts(size);
                IList<PostIndexVM> postIndexVMs = new List<PostIndexVM>();
                foreach (var post in posts)
                {
                    postIndexVMs.Add(new PostIndexVM()
                    {
                        PostId = post.PostId,
                        Title = post.Title,
                        ShortDescription = post.ShortDescription,
                        UrlSlug = post.UrlSlug,
                        Published = post.Published,
                        PostedOn = post.PostedOn,
                        Modified = post.Modified,
                        ViewCount = post.ViewCount,
                        Rate = post.Rate,
                        CategoryId = post.CategoryId,
                        CategoryName = post.Category.CategoryName
                    });
                }
                responseResult.Data = postIndexVMs;
                return responseResult;
            }
            catch (Exception ex)
            {
                return new ResponseResult<IList<PostIndexVM>>("Error: " + ex.Message);
            }
        }

        public ResponseResult<IList<PostIndexVM>> GetPublishedPosts()
        {
            try
            {
                ResponseResult<IList<PostIndexVM>> responseResult = new();
                var posts = _unitOfWork.PostRepository.GetPublishedPosts();
                IList<PostIndexVM> postIndexVMs = new List<PostIndexVM>();
                foreach (var post in posts)
                {
                    postIndexVMs.Add(new PostIndexVM()
                    {
                        PostId = post.PostId,
                        Title = post.Title,
                        ShortDescription = post.ShortDescription,
                        UrlSlug = post.UrlSlug,
                        Published = post.Published,
                        PostedOn = post.PostedOn,
                        Modified = post.Modified,
                        ViewCount = post.ViewCount,
                        Rate = post.Rate,
                        CategoryId = post.CategoryId,
                        CategoryName = post.Category.CategoryName
                    });
                }
                responseResult.Data = postIndexVMs;
                return responseResult;
            }
            catch (Exception ex)
            {
                return new ResponseResult<IList<PostIndexVM>>("Error: " + ex.Message);
            }
        }

        public ResponseResult<IList<PostIndexVM>> GetUnpublishedPosts()
        {
            try
            {
                ResponseResult<IList<PostIndexVM>> responseResult = new();
                var posts = _unitOfWork.PostRepository.GetUnpublishedPosts();
                IList<PostIndexVM> postIndexVMs = new List<PostIndexVM>();
                foreach (var post in posts)
                {
                    postIndexVMs.Add(new PostIndexVM()
                    {
                        PostId = post.PostId,
                        Title = post.Title,
                        ShortDescription = post.ShortDescription,
                        UrlSlug = post.UrlSlug,
                        Published = post.Published,
                        PostedOn = post.PostedOn,
                        Modified = post.Modified,
                        ViewCount = post.ViewCount,
                        Rate = post.Rate,
                        CategoryId = post.CategoryId,
                        CategoryName = post.Category.CategoryName
                    });
                }
                responseResult.Data = postIndexVMs;
                return responseResult;
            }
            catch (Exception ex)
            {
                return new ResponseResult<IList<PostIndexVM>>("Error: " + ex.Message);
            }
        }
    }
}
