using FA.JustBlog.Core.Data;
using FA.JustBlog.Core.Infrastructures;
using NUnit.Framework;
using System.Linq;

namespace FA.JustBlog.UnitTest
{
    [TestFixture]
    public class CategoryRepositoryTests
    {
        private IUnitOfWork _unitOfWork;

        [SetUp]
        public void SetUp()
        {
        }

        [Test]
        public void GetAll_WhenCalled_ReturnListCategories()
        {
            using (var db = new JustBlogContext())
            {
                _unitOfWork = new UnitOfWork(db);
                var result = _unitOfWork.CategoryRepository.GetAll();
                Assert.That(result.Count(), Is.EqualTo(10));
            }
        }

        [Test]
        [TestCase(1)]
        [TestCase(3)]
        [TestCase(4)]
        public void Find_EnterCategoryId_ReturnCategoryById(int id)
        {
            using (var db = new JustBlogContext())
            {
                _unitOfWork = new UnitOfWork(db);
                var result = _unitOfWork.CategoryRepository.Find(id);
                Assert.That(result.CategoryId, Is.EqualTo(id));
            }   
        }

    }
}