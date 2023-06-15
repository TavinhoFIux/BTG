using Moq;
using WebApi.Application.Models;
using WebApi.Services;

namespace WebApi.Tests.Mock
{
    public class ProductServiceMock: Mock<IProductService>
    {
        public ProductServiceMock() : base(MockBehavior.Strict) { }

        public ProductServiceMock GetAllProductMock(List<Product> output)
        {
            Setup(m => m.GetAllProductAsync()).ReturnsAsync(output);
            return this;
        }
    }
}
