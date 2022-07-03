using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace FA.JustBlog.Core.Models
{
    public class User : IdentityUser
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        public int Age { get; set; }

        [StringLength(255)]
        public string? Address { get; set; }
        public string? AboutMe{ get; set; }
    }
}
