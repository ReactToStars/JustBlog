using System.ComponentModel.DataAnnotations;

namespace FA.JustBlog.Core.Models
{
    public class Tag
    {
        [Key]
        public int TagId { get; set; }
        [StringLength(255)]
        [Required(ErrorMessage ="Tag name is required")]
        public string TagName { get; set; }
        [StringLength(255)]
        public string UrlSlug { get; set; }
        [StringLength(1024)]
        public string Description { get; set; }
        public int? Count { get; set; }
        public IList<PostTagMap> PostTagMaps { get; set; }
    }
}
