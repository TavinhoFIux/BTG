using FluentValidation;
using FluentValidation.Results;
using WebApi.Domain.Messages;

namespace WebApi.Application.Commands
{
    public class DeleteProductCommand: Command
    {
        public int Id { get; set; }


        public DeleteProductCommand(int id)
        {
            Id = id;
        }

        public override ValidationResult Validate()
        {
            return new DeleteProductValidation().Validate(this);
        }

        public class DeleteProductValidation : AbstractValidator<DeleteProductCommand>
        {
            public DeleteProductValidation()
            {

            }
        }
    }
}
