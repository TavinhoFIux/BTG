using Moq;
using WebApi.Domain.Messages;
using WebApi.Domain.Notifications;

namespace WebApi.Tests.Mock
{
    public class ErrorHandlerMock : Mock<IErrorHandler>
    {
        public ErrorHandlerMock() : base(MockBehavior.Strict) { }

        public ErrorHandlerMock MockValidateCommand(Command command, bool output)
        {
            Setup(m => m.ValidateCommand(command)).Returns(output);
            return this;
        }
    }
}
