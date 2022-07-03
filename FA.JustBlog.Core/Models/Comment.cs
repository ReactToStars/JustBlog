using System.ComponentModel.DataAnnotations;

namespace FA.JustBlog.Core.Models
{
    public class Comment
    {
        [Key]
        public int CommentId { get; set; }
        [Required(ErrorMessage = "Name is required")]
        [StringLength(50)]
        public string Name { get; set; }
        [Required(ErrorMessage = "Name is required")]
        [StringLength(100)]
        public string Email { get; set; }
        public string CommentHeader { get; set; }
        public string CommentText { get; set; }
        public DateTime CommentTime { get; set; }

        public int PostId { get; set; }
        public Post Post { get; set; }
    }
}
