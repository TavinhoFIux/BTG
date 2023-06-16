using MediatR;
using WebApi.Application.Commands;
using WebApi.Application.Handlers.Notifications;
using WebApi.Application.Models;
using WebApi.Infrastructure.Errors;
using WebApi.Repository;

namespace WebApi.Application.Handlers
{
    public class EditProductCommandHandler : IRequestHandler<EditProductCommand>
    {
        private readonly IMediator _mediator;
        private readonly IErrorHandler _errorHandler;
        private readonly IRepositoryProduct _repositoryProduct;

        public EditProductCommandHandler(IMediator mediator, IErrorHandler errorHandler, IRepositoryProduct repositoryProduct)
        {
            _mediator = mediator;
            _errorHandler = errorHandler;
            _repositoryProduct = repositoryProduct;
        }

        public async Task<Unit> Handle(EditProductCommand request, CancellationToken cancellationToken)
        {
            if (!_errorHandler.ValidateCommand(request))
            {
                return Unit.Value;
            }

            Product product = new(request.Id, request.Name);

            try
            {
                await _repositoryProduct.EditAsync(product);
            }
            catch
            {
                _errorHandler.Add(ErrorValidate.FailEditProduct);
            }

            return Unit.Value;
        }
    }
}
