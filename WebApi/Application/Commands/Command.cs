using FluentValidation.Results;
using MediatR;

namespace WebApi.Application.Commands
{
    public class Command : IRequest
    {
        public DateTimeOffset Timestamp { get; }

        protected Command()
        {
            Timestamp = DateTimeOffset.UtcNow;
        }

        public virtual ValidationResult Validate()
        {
            throw new NotImplementedException();
        }
    }
}
