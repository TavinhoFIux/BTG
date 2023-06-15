using MediatR;
using WebApi.Application.Commands;
using WebApi.Application.Models;
using WebApi.Domain.Notifications;
using WebApi.Infrastructure.Errors;
using WebApi.Repository;

namespace WebApi.Application.Handlers
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand>
    {
        private readonly IMediator _mediator;
        private readonly IErrorHandler _errorHandler;
        private readonly IRepositoryProduct _repositoryProduct;

        public DeleteProductCommandHandler(IMediator mediator, IErrorHandler errorHandler, IRepositoryProduct repositoryProduct)
        {
            _mediator = mediator;
            _errorHandler = errorHandler;
            _repositoryProduct = repositoryProduct;
        }

        public async Task<Unit> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            if (!_errorHandler.ValidateCommand(request))
            {
                return Unit.Value;
            }


            try
            {
                await _repositoryProduct.DeleteAsync(request.Id);
            }
            catch
            {
                _errorHandler.Add(ErrorValidate.FailDeleteProduct);
            }

            return Unit.Value;
        }


    }
}
