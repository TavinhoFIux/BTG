using Moq;
using WebApi.Application.Commands;
using WebApi.Application.Handlers.Notifications;

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
