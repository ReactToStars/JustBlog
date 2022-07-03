using FA.JustBlog.Core.Data;
using FA.JustBlog.Core.Models;
using FA.JustBlog.Utility;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace FA.JustBlog.Core.SeedData
{
    public class DbInitializer : IDbInitializer
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly JustBlogContext _db;

        public DbInitializer(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager,
            JustBlogContext db)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _db = db;
        }
        public void Initialize()
        {
            //Migration if they are not applied
            try
            {
                if (_db.Database.GetPendingMigrations().Count() > 0)
                {
                    _db.Database.Migrate();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            //Create Roles if they are not Created

            if (!_roleManager.RoleExistsAsync(SD.ROLE_ADMIN).GetAwaiter().GetResult())
            {
                _roleManager.CreateAsync(new IdentityRole(SD.ROLE_ADMIN)).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole(SD.ROLE_GUEST)).GetAwaiter().GetResult();

                _userManager.CreateAsync(new User
                {
                    UserName = "admin@gmail.com",
                    Email = "admin@gmail.com",
                    Name = "Nguyen Trong Hung",
                    Age = 22,
                    Address = "Tan Lap, Dan Phuong, Ha Noi",
                    AboutMe = "I'm a developer of FPT software"
                }, "Admin123@").GetAwaiter().GetResult();

                User admin = _db.Users.FirstOrDefault(x => x.UserName == "admin@gmail.com");
                _userManager.AddToRoleAsync(admin, SD.ROLE_ADMIN).GetAwaiter().GetResult();
            }

            if (!_roleManager.RoleExistsAsync(SD.ROLE_USER).GetAwaiter().GetResult())
            {
                _roleManager.CreateAsync(new IdentityRole(SD.ROLE_USER)).GetAwaiter().GetResult();

                _userManager.CreateAsync(new User
                {
                    UserName = "user@gmail.com",
                    Email = "user@gmail.com",
                    Name = "User",
                    Age = 22,
                    Address = "Tan Lap, Dan Phuong, Ha Noi",
                    AboutMe = "I'm a developer of FPT software"
                }, "User123@").GetAwaiter().GetResult();

                User user = _db.Users.FirstOrDefault(x => x.UserName == "user@gmail.com");
                _userManager.AddToRoleAsync(user, SD.ROLE_USER).GetAwaiter().GetResult();
            }
        }

        public void SeedData()
        {
            _db.Database.EnsureCreated();
            if (!_db.Categories.Any())
            {
                List<Category> categories = new List<Category>()
                {
                    new Category { CategoryName = "Category 1", Description = "This is Category 1", UrlSlug = "title-10",
                    Posts = new []
                        {
                            new Post
                            {
                                Title = "Title 1",
                                ShortDescription = "Hello ban nho",
                                PostContent = "You can insert data into your database tables during the database initialization process." +
                                " This will be important if you want to provide some test data for your" +
                                " application or some default master data for your application.",
                                UrlSlug = "title-10",
                                Published = true,
                                PostedOn = DateTime.Now,
                                Modified = DateTime.Now,
                                CategoryId = 1,
                                ViewCount = 100,
                                RateCount = 30,
                                TotalRate = 80,
                            },
                            new Post
                            {
                                Title = "Title 2",
                                ShortDescription = "Hello ban nho",
                                PostContent = "You can insert data into your database tables during the database initialization process." +
                                " This will be important if you want to provide some test data for your" +
                                " application or some default master data for your application.",
                                UrlSlug = "title-10",
                                Published = true,
                                PostedOn = DateTime.Now,
                                Modified = DateTime.Now,
                                CategoryId = 2,
                                ViewCount = 150,
                                RateCount = 30,
                                TotalRate = 80,
                            },
                        }
                    },
                    new Category { CategoryName = "Category 2", Description = "This is Category 2", UrlSlug = "title-10",
                                    Posts= new []
                                    {
                                        new Post
                                        {
                                            Title = "Title 3",
                                            ShortDescription = "Hello ban nho",
                                            PostContent = "You can insert data into your database tables during the database initialization process." +
                                            " This will be important if you want to provide some test data for your" +
                                            " application or some default master data for your application.",
                                            UrlSlug = "title-10",
                                            Published = false,
                                            PostedOn = DateTime.Now,
                                            Modified = DateTime.Now,
                                            CategoryId = 3,
                                            ViewCount = 100,
                                            RateCount = 40,
                                            TotalRate = 80,
                                        },
                                        new Post
                                        {
                                            Title = "Title 4",
                                            ShortDescription = "Hello ban nho",
                                            PostContent = "You can insert data into your database tables during the database initialization process." +
                                            " This will be important if you want to provide some test data for your" +
                                            " application or some default master data for your application.",
                                            UrlSlug = "title-10",
                                            Published = true,
                                            PostedOn = DateTime.Now,
                                            Modified = DateTime.Now,
                                            CategoryId = 4,
                                            ViewCount = 100,
                                            RateCount = 30,
                                            TotalRate = 70,
                                        },
                                        new Post
                                        {
                                            Title = "Title 5",
                                            ShortDescription = "Hello ban nho",
                                            PostContent = "You can insert data into your database tables during the database initialization process." +
                                            " This will be important if you want to provide some test data for your" +
                                            " application or some default master data for your application.",
                                            UrlSlug = "title-10",
                                            Published = false,
                                            PostedOn = DateTime.Now,
                                            Modified = DateTime.Now,
                                            CategoryId = 5,
                                            ViewCount = 100,
                                            RateCount = 30,
                                            TotalRate = 90,
                                        },
                                    }
                    },
                    new Category { CategoryName = "Category 3", Description = "This is Category 3", UrlSlug = "title-10",
                        Posts  = new []
                        {
                            new Post
                            {
                                Title = "Title 6",
                                ShortDescription = "Hello ban nho",
                                PostContent = "You can insert data into your database tables during the database initialization process." +
                                " This will be important if you want to provide some test data for your" +
                                " application or some default master data for your application.",
                                UrlSlug = "title-10",
                                Published = true,
                                PostedOn = DateTime.Now,
                                Modified = DateTime.Now,
                                CategoryId = 6,
                                ViewCount = 100,
                                RateCount = 30,
                                TotalRate = 120,
                            },
                            new Post
                            {
                                Title = "Title 7",
                                ShortDescription = "Hello ban nho",
                                PostContent = "You can insert data into your database tables during the database initialization process." +
                                " This will be important if you want to provide some test data for your" +
                                " application or some default master data for your application.",
                                UrlSlug = "title-10",
                                Published = false,
                                PostedOn = DateTime.Now,
                                Modified = DateTime.Now,
                                CategoryId = 7,
                                ViewCount = 60,
                                RateCount = 30,
                                TotalRate = 80,
                            },
                            new Post
                            {
                                Title = "Title 8",
                                ShortDescription = "Hello ban nho",
                                PostContent = "You can insert data into your database tables during the database initialization process." +
                                " This will be important if you want to provide some test data for your" +
                                " application or some default master data for your application.",
                                UrlSlug = "title-8",
                                Published = true,
                                PostedOn = DateTime.Now,
                                Modified = DateTime.Now,
                                CategoryId = 8,
                            },
                            new Post
                            {
                                Title = "Title 9",
                                ShortDescription = "Hello ban nho",
                                PostContent = "You can insert data into your database tables during the database initialization process." +
                                " This will be important if you want to provide some test data for your" +
                                " application or some default master data for your application.",
                                UrlSlug = "title-9",
                                Published = true,
                                PostedOn = DateTime.Now,
                                Modified = DateTime.Now,
                                CategoryId = 9,
                            },
                            new Post
                            {
                                Title = "Title 10",
                                ShortDescription = "Hello ban nho",
                                PostContent = "You can insert data into your database tables during the database initialization process." +
                                " This will be important if you want to provide some test data for your" +
                                " application or some default master data for your application.",
                                UrlSlug = "title-10",
                                Published = false,
                                PostedOn = DateTime.Now,
                                Modified = DateTime.Now,
                                CategoryId = 10,
                            }
                        }
                    },
                    new Category { CategoryName = "Category 4", Description = "This is Category 4", UrlSlug = "title-10" },
                    new Category { CategoryName = "Category 5", Description = "This is Category 5", UrlSlug = "title-10" },
                    new Category { CategoryName = "Category 6", Description = "This is Category 6", UrlSlug = "title-10" },
                    new Category { CategoryName = "Category 7", Description = "This is Category 7", UrlSlug = "title-10" },
                    new Category { CategoryName = "Category 8", Description = "This is Category 8", UrlSlug = "title-10" },
                    new Category { CategoryName = "Category 9", Description = "This is Category 9", UrlSlug = "title-10" },
                    new Category { CategoryName = "Category 10", Description = "This is Category 10", UrlSlug = "title-10" }
                };
                _db.Categories.AddRange(categories);
            }

            if (!_db.Tags.Any())
            {
                List<Tag> tags = new List<Tag>()
                {
                     new Tag {TagName = "Tag 1", Description = "This is tag 1", Count = 1, UrlSlug = "title-10" },
                    new Tag {TagName = "Tag 2", Description = "This is tag 2", Count = 2, UrlSlug = "title-10" },
                    new Tag { TagName = "Tag 3", Description = "This is tag 3", Count = 3, UrlSlug = "title-10" },
                    new Tag { TagName = "Tag 4", Description = "This is tag 4", Count = 4, UrlSlug = "title-10" },
                    new Tag { TagName = "Tag 5", Description = "This is tag 5", Count = 5, UrlSlug = "title-10" },
                    new Tag { TagName = "Tag 6", Description = "This is tag 6", Count = 6, UrlSlug = "title-10" },
                    new Tag { TagName = "Tag 7", Description = "This is tag 7", Count = 7, UrlSlug = "title-10" },
                    new Tag { TagName = "Tag 8", Description = "This is tag 8", Count = 8, UrlSlug = "title-10" },
                    new Tag { TagName = "Tag 9", Description = "This is tag 9", Count = 9, UrlSlug = "title-10" },
                    new Tag { TagName = "Tag 10", Description = "This is tag 10", Count = 10, UrlSlug = "title-10" }
                };
                _db.Tags.AddRange(tags);
            }

            //if (!_db.PostTagMaps.Any())
            //{
            //    List<PostTagMap> postTagMaps = new List<PostTagMap>()
            //    {
            //        new PostTagMap { PostId = 1, TagId = 1 },
            //        new PostTagMap { PostId = 2, TagId = 2 },
            //        new PostTagMap { PostId = 3, TagId = 1 },
            //        new PostTagMap { PostId = 4, TagId = 3 },
            //        new PostTagMap { PostId = 5, TagId = 1 },
            //        new PostTagMap { PostId = 6, TagId = 5 },
            //        new PostTagMap { PostId = 7, TagId = 1 },
            //        new PostTagMap { PostId = 8, TagId = 7 },
            //        new PostTagMap { PostId = 9, TagId = 9 },
            //        new PostTagMap { PostId = 10, TagId = 1 }
            //    };
            //    _db.PostTagMaps.AddRange(postTagMaps);
            //}

            _db.SaveChanges();
        }
    }
}
