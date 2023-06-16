using FluentValidation;
using FluentValidation.Results;

namespace WebApi.Application.Commands
{
    public class DeleteProductCommand: Command
    {
        public int Id { get; set; }


        public DeleteProductCommand(int id)
        {
            Id = id;
        }
    }
}

