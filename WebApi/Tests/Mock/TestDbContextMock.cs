using Moq;
using WebApi.Application.Models;
using WebApi.Repository;

namespace WebApi.Tests.Mock
{
    public class  TestDbContextMock : Mock<TestDbContext>
    {
       public  TestDbContextMock(): base(MockBehavior.Strict) { }

        public virtual TestDbContextMock GetAllProductDb(List<Product> products)
        {
            Setup(m => m.Products.OrderBy(It.IsAny<Func<Product, bool>>()).ToList()).Returns(products);
            return this;
        }
    }
}
