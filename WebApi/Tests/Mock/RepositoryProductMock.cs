using FluentResults;
using Moq;
using WebApi.Application.Models;
using WebApi.Repository;

namespace WebApi.Tests.Mock
{
    public class RepositoryProductMock : Mock<IRepositoryProduct>
    {
        public RepositoryProductMock() : base(MockBehavior.Strict) { }

        public RepositoryProductMock GetAllMock(List<Product> output)
        {
            Setup(m => m.GetAllAsync()).ReturnsAsync(output);
            return this;
        }
        public RepositoryProductMock GetAllMock()
        {
            Setup(m => m.GetAllAsync()).Throws<System.Exception>();
            return this;
        }
    }
}
