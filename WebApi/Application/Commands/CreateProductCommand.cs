using FluentValidation;
using FluentValidation.Results;
using WebApi.Domain.Messages;

namespace WebApi.Application.Commands
{
    public class CreateProductCommand : Command
    {
        public string Name { get; set; }


        public CreateProductCommand(string name)
        {
            Name = name;
        }

        public override ValidationResult Validate()
        {
            return new CreateProductValidation().Validate(this);
        }

        public class CreateProductValidation : AbstractValidator<CreateProductCommand>
        {
            public CreateProductValidation()
            {
                RuleFor(C => C.Name)
                    .NotEmpty()
                        .WithMessage("O produto precisa de um nome!");

                RuleFor(C => C.Name)
                   .MinimumLength(4)
                       .WithMessage("O nome do produto precisa de pelo menos 4 caractere!");

            }
        }
    }
}
