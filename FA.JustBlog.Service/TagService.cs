using FA.JustBlog.Core.Infrastructures;
using FA.JustBlog.Core.Models;
using FA.JustBlog.Service.IServices;
using FA.JustBlog.ViewModels.Tags;

namespace FA.JustBlog.Service
{
    public class TagService : ITagService
    {
        private readonly IUnitOfWork _unitOfWork;

        public TagService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public ResponseResult<TagVM> Add(TagVM entity)
        {
            try
            {
                Tag tag= new Tag();
                tag.TagName = entity.TagName;
                tag.Description = entity.Description;
                tag.UrlSlug = entity.UrlSlug;
                tag.Count = entity.Count;
                _unitOfWork.TagRepository.Add(tag);
                _unitOfWork.SaveChanges();
                return new ResponseResult<TagVM>();
            }
            catch (Exception ex)
            {
                return new ResponseResult<TagVM>("Error: " + ex.Message);
            }
        }

        public ResponseResult<TagVM> Delete(int id)
        {
            try
            {
                _unitOfWork.TagRepository.Delete(id);
                _unitOfWork.SaveChanges();
                return new ResponseResult<TagVM>();
            }
            catch (Exception ex)
            {
                return new ResponseResult<TagVM>("Error: "+ ex.Message);
            }
        }

        public ResponseResult<TagVM> Delete(TagVM entity)
        {
            try
            {
                Tag tag = new();
                tag.TagId = entity.TagId;
                tag.TagName = entity.TagName;
                tag.UrlSlug = entity.UrlSlug;
                tag.Description = entity.Description;
                _unitOfWork.TagRepository.Delete(tag);
                _unitOfWork.SaveChanges();
                return new ResponseResult<TagVM>();
            }
            catch (Exception ex)
            {
                return new ResponseResult<TagVM>("Error" + ex.Message);
            }
        }

        public ResponseResult<TagVM> Find(int id)
        {
            try
            {
                var tag = _unitOfWork.TagRepository.Find(id);
                if (tag != null)
                {
                    TagVM tagVM = new TagVM();
                    tagVM.TagId = tag.TagId;
                    tagVM.TagName = tag.TagName;
                    tagVM.UrlSlug = tag.UrlSlug;
                    tagVM.Description = tag.Description;
                    tagVM.Count = tag.Count;
                    ResponseResult<TagVM> responseResult = new ResponseResult<TagVM>();
                    responseResult.Data = tagVM;
                    return responseResult;
                }
                return new ResponseResult<TagVM>("Khong tim thay");
            }
            catch (Exception ex)
            {
                return new ResponseResult<TagVM>("Error: " + ex.Message);
            }
        }

        public ResponseResult<IList<TagVM>> GetAll()
        {
            try
            {
                ResponseResult<IList<TagVM>> responseResult = new();
                var tags = _unitOfWork.TagRepository.GetAll();
                IList<TagVM> TagVMs = new List<TagVM>();
                foreach (var tag in tags)
                {
                    TagVMs.Add(new TagVM()
                    {
                        TagId = tag.TagId,
                        TagName = tag.TagName,
                        UrlSlug = tag.UrlSlug,
                        Description = tag.Description,
                        Count = tag.Count
                    });
                }
                responseResult.Data = TagVMs;
                return responseResult;
            }
            catch (Exception ex)
            {
                return new ResponseResult<IList<TagVM>>("Error: "+ex.Message);
            }
        }

        public ResponseResult<IList<TagVM>> GetPopularTags(int size)
        {
            try
            {
                ResponseResult<IList<TagVM>> responseResult = new();
                var tags = _unitOfWork.TagRepository.GetPopularTags(size);
                IList<TagVM> TagVMs = new List<TagVM>();
                foreach (var tag in tags)
                {
                    TagVMs.Add(new TagVM()
                    {
                        TagId = tag.TagId,
                        TagName = tag.TagName,
                        UrlSlug = tag.UrlSlug,
                        Description = tag.Description,
                        Count = tag.Count
                    });
                }
                responseResult.Data = TagVMs;
                return responseResult;
            }
            catch (Exception ex)
            {
                return new ResponseResult<IList<TagVM>>("Error: " + ex.Message);
            }
        }

        public ResponseResult<IList<TagVM>> GetTagsByPost(int postId)
        {
            try
            {
                ResponseResult<IList<TagVM>> responseResult = new();
                var tags = _unitOfWork.TagRepository.GetTagsByPost(postId);
                IList<TagVM> TagVMs = new List<TagVM>();
                foreach (var tag in tags)
                {
                    TagVMs.Add(new TagVM()
                    {
                        TagId = tag.TagId,
                        TagName = tag.TagName,
                        UrlSlug = tag.UrlSlug,
                        Description = tag.Description,
                        Count = tag.Count
                    });
                }
                responseResult.Data = TagVMs;
                return responseResult;
            }
            catch (Exception ex)
            {
                return new ResponseResult<IList<TagVM>>("Error: " + ex.Message);
            }
        }

        public ResponseResult<TagVM> Update(TagVM entity)
        {
            try
            {
                var tag = new Tag()
                {
                    TagId = entity.TagId,
                    TagName = entity.TagName,
                    UrlSlug = entity.UrlSlug,
                    Description = entity.Description,
                    Count = entity.Count
                };
                _unitOfWork.TagRepository.Update(tag);
                _unitOfWork.SaveChanges();
                return new ResponseResult<TagVM>();
            }
            catch (Exception ex)
            {
                return new ResponseResult<TagVM>("Error: " + ex.Message);
            }
        }
    }
}
