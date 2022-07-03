using FA.JustBlog.Core.Infrastructures;
using FA.JustBlog.Core.Models;
using FA.JustBlog.Service.IServices;
using FA.JustBlog.ViewModels.Comments;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FA.JustBlog.Service
{
    public class CommentService : ICommentService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CommentService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public ResponseResult<CommentVM> Add(CommentVM entity)
        {
            try
            {
                Comment comment = new Comment()
                {
                    Name = entity.Name,
                    Email = entity.Email,
                    CommentHeader = entity.CommentHeader,
                    CommentText = entity.CommentText,
                    PostId = entity.PostId,
                };
                _unitOfWork.CommentRepository.Add(comment);
                _unitOfWork.SaveChanges();
                return new ResponseResult<CommentVM>();
            }
            catch (Exception ex)
            {
                return new ResponseResult<CommentVM>("Error: " + ex.Message);
            }
        }

        public ResponseResult<CommentVM> Delete(int id)
        {
            try
            {
                _unitOfWork.CommentRepository.Delete(id);
                _unitOfWork.SaveChanges();
                return new ResponseResult<CommentVM>();
            }
            catch (Exception ex)
            {
                return new ResponseResult<CommentVM>("Error: " + ex.Message);
            }
        }

        public ResponseResult<CommentVM> Delete(CommentVM entity)
        {
            try
            {
                Comment comment = new()
                {
                    CommentId = entity.CommentId,
                };
                _unitOfWork.CommentRepository.Delete(comment);
                _unitOfWork.SaveChanges();
                return new ResponseResult<CommentVM>();
            }
            catch (Exception ex)
            {
                return new ResponseResult<CommentVM>("Error" + ex.Message);
            }
        }

        public ResponseResult<CommentVM> Find(int id)
        {
            try
            {
                var comment = _unitOfWork.CommentRepository.Find(id);
                if (comment != null)
                {
                    CommentVM commentVM = new CommentVM()
                    {
                        CommentId = comment.CommentId,
                        Name = comment.Name,
                        Email = comment.Email,
                        CommentHeader = comment.CommentHeader,
                        CommentText = comment.CommentText,
                        PostId = comment.PostId,
                        PostTitle = comment.Post.Title,
                        ListPost = GetListPost(),
                    };
                    ResponseResult<CommentVM> responseResult = new ResponseResult<CommentVM>();
                    responseResult.Data = commentVM;
                    return responseResult;
                }
                return new ResponseResult<CommentVM>("Cannot Found");
            }
            catch (Exception ex)
            {
                return new ResponseResult<CommentVM>("Error: " + ex.Message);
            }
        }

        public ResponseResult<IList<CommentVM>> GetAll()
        {
            try
            {
                ResponseResult<IList<CommentVM>> responseResult = new();
                var comments = _unitOfWork.CommentRepository.GetAll();
                IList<CommentVM> commentVMs = new List<CommentVM>();
                foreach (var comment in comments)
                {
                    commentVMs.Add(new CommentVM()
                    {
                        CommentId = comment.CommentId,
                        Name = comment.Name,
                        Email = comment.Email,
                        CommentHeader = comment.CommentHeader,
                        CommentText = comment.CommentText,
                        PostId = comment.PostId,
                    });
                }
                responseResult.Data = commentVMs;
                return responseResult;
            }
            catch (Exception ex)
            {
                return new ResponseResult<IList<CommentVM>>("Error: " + ex.Message);
            }
        }

        public ResponseResult<CommentVM> GetDetails(int id)
        {
            try
            {
                Comment commentExisting = _unitOfWork.CommentRepository.Find(id);
                CommentVM CommentVM = new CommentVM()
                {
                    CommentId = commentExisting.CommentId,
                    Name = commentExisting.Name,
                    Email = commentExisting.Email,
                    CommentHeader = commentExisting.CommentHeader,
                    CommentText = commentExisting.CommentText,
                    PostId = commentExisting.PostId,
                };
                ResponseResult<CommentVM> responseResult = new ResponseResult<CommentVM>();
                responseResult.Data = CommentVM;
                return responseResult;
            }
            catch (Exception ex)
            {
                return new ResponseResult<CommentVM>("Error" + ex.Message);
            }
        }

        public ResponseResult<CommentVM> Update(CommentVM entity)
        {
            try
            {
                var comment = new Comment()
                {
                    CommentId = entity.CommentId,
                    Name = entity.Name,
                    Email = entity.Email,
                    CommentHeader = entity.CommentHeader,
                    CommentText = entity.CommentText,
                    PostId = entity.PostId,
                };
                _unitOfWork.CommentRepository.Update(comment);
                _unitOfWork.SaveChanges();
                return new ResponseResult<CommentVM>();
            }
            catch (Exception ex)
            {
                return new ResponseResult<CommentVM>("Error: " + ex.Message);
            }
        }

        public IEnumerable<SelectListItem> GetListPost()
        {
            return _unitOfWork.PostRepository.GetAll().Select(
                u => new SelectListItem
                {
                    Text = u.Title,
                    Value = u.PostId.ToString(),
                });
        }
    }
}
