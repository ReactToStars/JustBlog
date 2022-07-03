using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FA.JustBlog.Core.Models
{
    public class Post
    {
        private decimal _rate;
        [Key]
        public int PostId { get; set; }
        [Required(ErrorMessage ="Title is required")]
        [StringLength(255)]
        public string Title { get; set; }
        [Required(ErrorMessage ="Short Description is required")]
        [StringLength(1024)]
        public string ShortDescription { get; set; }
        [Required(ErrorMessage ="Content is required")]
        public string PostContent { get; set; }
        [StringLength(255)]
        public string UrlSlug { get; set; }
        public bool Published { get; set; }
        public DateTime PostedOn { get; set; } = DateTime.Now;
        public DateTime? Modified { get; set; }
        
        public int ViewCount { get; set; }
        public int RateCount { get; set; }
        public int TotalRate { get; set; }
        [NotMapped]
        public decimal Rate 
        {
            get => _rate;
            set{
                if (RateCount != 0)
                {
                    _rate = TotalRate / RateCount;
                }
                _rate = 0;
            }
        }

        public int? CategoryId { get; set; }
        public Category Category { get; set; } //virtual => lazy coding
        public IList<PostTagMap> PostTagMaps{ get; set; }
        public IList<Comment> Comments { get; set; }
    }
}
