using FluentValidation.Results;
using WebApi.Application.Commands;
using WebApi.Infrastructure.Errors;

namespace WebApi.Application.Handlers.Notifications
{
    public class ErrorHandler : IErrorHandler
    {
        private ErrorResult? _error;

        public bool ValidateCommand(Command command)
        {
            ValidationResult validationResult = command.Validate();

            if (validationResult.IsValid)
            {
                return true;
            }

            Add(validationResult);

            return false;
        }

        public void Add(ValidationResult validationResult)
        {
            if (validationResult.IsValid)
            {
                throw new InvalidOperationException("Cannot add validation result error that has no error.");
            }

            BadRequestError httpError = BadRequestError.InvalidFields;
            var errorMessage = new ErrorMessage(httpError.Id, httpError.Name);
            var errors = new List<ErrorItem>();

            foreach (ValidationFailure error in validationResult.Errors)
            {
                errors.Add(new ErrorItem(error.ErrorCode, error.ErrorMessage));
            }

            var errorDetail = new ErrorDetail(httpError.Status, errorMessage, errors);
            _error = new ErrorResult(errorDetail);
        }
        public void Add(HttpErrorBase httpError)
        {
            if (httpError is null)
            {
                throw new ArgumentNullException(nameof(httpError));
            }

            var errorMessage = new ErrorMessage(httpError.Id, httpError.Name);
            var error = new ErrorDetail(httpError.Status, errorMessage, null);
            _error = new ErrorResult(error);
        }

        public bool HasError() => _error is not null;

        public ErrorResult GetError() => _error ?? throw new InvalidOperationException("Cannot get error when there is no error.");
    }
}
