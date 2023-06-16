using MediatR;
using WebApi.Application.Commands;
using WebApi.Application.Handlers.Notifications;
using WebApi.Application.Models;
using WebApi.Infrastructure.Errors;
using WebApi.Repository;

namespace WebApi.Application.Handlers
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand>
    {
        private readonly IMediator _mediator;
        private readonly IErrorHandler _errorHandler;
        private readonly IRepositoryProduct _repositoryProduct;

        public CreateProductCommandHandler(IMediator mediator, IErrorHandler errorHandler, IRepositoryProduct repositoryProduct)
        {
            _mediator = mediator;
            _errorHandler = errorHandler;   
            _repositoryProduct = repositoryProduct;
        }

        public async Task<Unit> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            if (!_errorHandler.ValidateCommand(request))
            {
                return Unit.Value;
            }

            Product product = new(request.Name);

            try 
            {
                await _repositoryProduct.AddAsync(product);
            }
            catch 
            {
                _errorHandler.Add(ErrorValidate.FailCreateProduct);
            }

            return Unit.Value;
        }
    }
}
