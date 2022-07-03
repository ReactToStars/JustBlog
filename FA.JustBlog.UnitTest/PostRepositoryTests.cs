using FA.JustBlog.Core.Data;
using FA.JustBlog.Core.Infrastructures;
using NUnit.Framework;
using System;
using System.Linq;

namespace FA.JustBlog.UnitTest
{
    [TestFixture]
    public class PostRepositoryTests
    {
        private IUnitOfWork _unitOfWork;
        [SetUp]
        public void SetUp()
        {

        }

        [Test]
        public void GetAll_WhenCalled_ReturnListPosts()
        {
            using (var db = new JustBlogContext())
            {
                _unitOfWork = new UnitOfWork(db);
                var result = _unitOfWork.PostRepository.GetAll();
                Assert.That(result.Count(), Is.EqualTo(10));
            }
        }

        [Test]
        [TestCase(1)]
        [TestCase(3)]
        [TestCase(5)]
        public void Find_EnterPostId_ReturnPostById(int id)
        {
            using (var db = new JustBlogContext())
            {
                _unitOfWork = new UnitOfWork(db);
                var result = _unitOfWork.PostRepository.Find(id);
                Assert.That(result.PostId, Is.EqualTo(id));
            }
        }

        [Test]
        [TestCase("Category 1")]
        [TestCase("Category 4")]
        [TestCase("Category 10")]
        public void CountPostsForCategory_EnterCategoryName_ReturnNumberOfPosts(string category)
        {
            using (var db = new JustBlogContext())
            {
                _unitOfWork = new UnitOfWork(db);
                var result = _unitOfWork.PostRepository.CountPostsForCategory(category);
                Assert.That(result, Is.EqualTo(1));
            }
        }

        [Test]
        [TestCase("Tag 1", 5)]
        [TestCase("Tag 2", 1)]
        [TestCase("Tag 3", 1)]
        public void CountPostsForTag_EnterTagName_ReturnNumberOfPosts(string tag, int output)
        {
            using (var db = new JustBlogContext())
            {
                _unitOfWork = new UnitOfWork(db);
                var result = _unitOfWork.PostRepository.CountPostsForTag(tag);
                Assert.That(result, Is.EqualTo(output));
            }
        }

        [Test]
        [TestCase(2022, 3, "https://www.entityframeworktutorial.net/code-first/seed-database-in-code-first.aspx", 1)]
        public void FindPost_EnterYearAndMonthAndUrlSlug_ReturnPost(int year, int month, string url, int output)
        {
            using (var db = new JustBlogContext())
            {
                _unitOfWork = new UnitOfWork(db);
                var result = _unitOfWork.PostRepository.FindPost(year, month, url);
                Assert.That(result.PostId, Is.EqualTo(output));
            }
        }

        [Test]
        [TestCase(3)]
        [TestCase(1)]
        [TestCase(5)]
        public void GetHighestPosts_EnterSize_ReturnListHighestPostsInSize(int size)
        {
            using (var db = new JustBlogContext())
            {
                _unitOfWork = new UnitOfWork(db);
                var result = _unitOfWork.PostRepository.GetHighestPosts(size);
                Assert.That(result.Count(), Is.EqualTo(size));
            }
        }

        [Test]
        [TestCase(3)]
        [TestCase(1)]
        [TestCase(5)]
        public void GetLatestPosts_EnterSize_ReturnListLatestPostsInSize(int size)
        {
            using (var db = new JustBlogContext())
            {
                _unitOfWork = new UnitOfWork(db);
                var result = _unitOfWork.PostRepository.GetLatestPosts(size);
                Assert.That(result.Count(), Is.EqualTo(size));
            }
        }

        [Test]
        [TestCase(3)]
        [TestCase(1)]
        [TestCase(5)]
        public void GetMostViewedPosts_EnterSize_ReturnListMostViewedPostsInSize(int size)
        {
            using (var db = new JustBlogContext())
            {
                _unitOfWork = new UnitOfWork(db);
                var result = _unitOfWork.PostRepository.GetMostViewedPosts(size);
                Assert.That(result.Count(), Is.EqualTo(size));
            }
        }

        [Test]
        [TestCase("Category 1", 1)]
        [TestCase("Category 2", 1)]
        [TestCase("Category 5", 1)]
        public void GetPostsByCategory_EnterCategoryName_ReturnListPostsByCategory(string categoryName, int output)
        {
            using (var db = new JustBlogContext())
            {
                _unitOfWork = new UnitOfWork(db);
                var result = _unitOfWork.PostRepository.GetPostsByCategoryName(categoryName);
                Assert.That(result.Count(), Is.EqualTo(output));
            }
        }

        [Test]
        public void GetPostsByMonth_EnterMarch_ReturnListPostsByMonth()
        {
            using (var db = new JustBlogContext())
            {
                _unitOfWork = new UnitOfWork(db);
                var result = _unitOfWork.PostRepository.GetPostsByMonth(new DateTime(2022,3,11));
                Assert.That(result.Count(), Is.EqualTo(10));
            }
        }

        [Test]
        [TestCase("Tag 1", 5)]
        [TestCase("Tag 2", 1)]
        [TestCase("Tag 3", 1)]
        public void GetPostsByTag_EnterTagName_ReturnNumberOfPosts(string tag, int output)
        {
            using (var db = new JustBlogContext())
            {
                _unitOfWork = new UnitOfWork(db);
                var result = _unitOfWork.PostRepository.GetPostsByTag(tag);
                Assert.That(result.Count(), Is.EqualTo(output));
            }
        }

        [Test]
        public void GetPublisedPosts_WhenCalled_ReturnNumberOfPosts()
        {
            using (var db = new JustBlogContext())
            {
                _unitOfWork = new UnitOfWork(db);
                var result = _unitOfWork.PostRepository.GetPublishedPosts();
                Assert.That(result.Count(), Is.EqualTo(10));
            }
        }

        [Test]
        public void GetUnPublisedPosts_WhenCalled_ReturnNumberOfPosts()
        {
            using (var db = new JustBlogContext())
            {
                _unitOfWork = new UnitOfWork(db);
                var result = _unitOfWork.PostRepository.GetUnpublishedPosts();
                Assert.That(result.Count(), Is.EqualTo(0));
            }
        }
    }
}
