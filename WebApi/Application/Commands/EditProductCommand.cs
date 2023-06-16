using FluentValidation;
using FluentValidation.Results;

namespace WebApi.Application.Commands
{
    public class EditProductCommand: Command
    {
        public string Name { get; set; }

        public int Id { get; set; }


        public EditProductCommand(string name, int id)
        {
            Id = id;
            Name = name;
        }

        public override ValidationResult Validate()
        {
            return new EditProductValidation().Validate(this);
        }

        public class EditProductValidation : AbstractValidator<EditProductCommand>
        {
            public EditProductValidation()
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
