using MediatR;
using Moq;

namespace WebApi.Tests.Mock
{
    public class MediatorMock : Mock<IMediator>
    {
        public MediatorMock() : base(MockBehavior.Strict) { }
    }
}
