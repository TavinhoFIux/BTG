using MediatR;
using Moq;
using WebApi.Domain.Notifications;

namespace WebApi.Tests.Mock
{
    public class MediatorMock : Mock<IMediator>
    {
        public MediatorMock() : base(MockBehavior.Strict) { }
    }
}
