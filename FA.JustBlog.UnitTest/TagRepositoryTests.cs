using FA.JustBlog.Core.Data;
using FA.JustBlog.Core.Infrastructures;
using NUnit.Framework;
using System.Linq;

namespace FA.JustBlog.UnitTest
{
    [TestFixture]
    public class TagRepositoryTests
    {
        private IUnitOfWork _unitOfWork;
        [SetUp]
        public void SetUp()
        {

        }

        [Test]
        public void GetAll_WhenCalled_ReturnListTags()
        {
            using (var db = new JustBlogContext())
            {
                _unitOfWork = new UnitOfWork(db);
                var result = _unitOfWork.TagRepository.GetAll();
                Assert.That(result.Count(), Is.EqualTo(10));
            }
        }

        [Test]
        [TestCase(1)]
        [TestCase(3)]
        [TestCase(5)]
        public void Find_EnterTagId_ReturnTagById(int id)
        {
            using (var db = new JustBlogContext())
            {
                _unitOfWork = new UnitOfWork(db);
                var result = _unitOfWork.TagRepository.Find(id);
                Assert.That(result.TagId, Is.EqualTo(id));
            }
        }

        [Test]
        [TestCase("https://www.entityframeworktutorial.net/code-first/setup-entity-framework-code-first-environment.aspx")]
        public void GetTagByUrlSlug_EnterUrlSlug_ReturnTagByUrlSlug(string url)
        {
            using (var db = new JustBlogContext())
            {
                _unitOfWork = new UnitOfWork(db);
                var result = _unitOfWork.TagRepository.GetTagByUrlSlug(url);
                Assert.That(result.UrlSlug, Is.EqualTo(url));
            }
        }

    }
}
