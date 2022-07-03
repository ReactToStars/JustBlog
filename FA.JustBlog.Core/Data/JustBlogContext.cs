using FA.JustBlog.Core.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FA.JustBlog.Core.Data
{
    public class JustBlogContext : IdentityDbContext
    {
        public JustBlogContext()
        {

        }
        public JustBlogContext(DbContextOptions<JustBlogContext> options) : base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Post> Posts{ get; set; }
        public DbSet<Tag> Tags{ get; set; }
        public DbSet<PostTagMap> PostTagMaps{ get; set; }
        public DbSet<Comment> Comments{ get; set; }
        public DbSet<User> Users { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            //optionsBuilder.UseSqlServer(@"server=DESKTOP-1VF5JA8;database=JustBlogDb;trusted_connection=true;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<PostTagMap>().HasKey(pt => new { pt.PostId, pt.TagId });

            modelBuilder.Entity<PostTagMap>()
                        .HasOne<Post>(pt => pt.Post)
                        .WithMany(p => p.PostTagMaps)
                        .HasForeignKey(pt => pt.PostId);

            modelBuilder.Entity<PostTagMap>()
                        .HasOne<Tag>(pt => pt.Tag)
                        .WithMany(t => t.PostTagMaps)
                        .HasForeignKey(pt => pt.TagId);

            modelBuilder.Entity<Post>()
                        .HasOne<Category>(p => p.Category)
                        .WithMany(c => c.Posts)
                        .HasForeignKey(p => p.CategoryId);

            //PostTagMaps
            //modelBuilder.Entity<PostTagMap>()
            //.HasData(
            //    new PostTagMap { PostId = 1, TagId = 1 },
            //    new PostTagMap { PostId = 2, TagId = 2 },
            //    new PostTagMap { PostId = 3, TagId = 1 },
            //    new PostTagMap { PostId = 4, TagId = 3 },
            //    new PostTagMap { PostId = 5, TagId = 1 },
            //    new PostTagMap { PostId = 6, TagId = 5 },
            //    new PostTagMap { PostId = 7, TagId = 1 },
            //    new PostTagMap { PostId = 8, TagId = 7 },
            //    new PostTagMap { PostId = 9, TagId = 9 },
            //    new PostTagMap { PostId = 10, TagId = 1 }
            //    );
        }

        
    }
}
