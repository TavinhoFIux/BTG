using Microsoft.AspNetCore.Mvc;
using WebApi.Application.Handlers.Notifications;
using WebApi.Infrastructure.Errors;

namespace WebApi.Controllers
{
    public class MainController : ControllerBase
    {
        private readonly IErrorHandler _errorHandler;

        protected MainController(IErrorHandler errorHandler)
        {
            _errorHandler = errorHandler ?? throw new ArgumentNullException(nameof(errorHandler));
        }

        protected IActionResult Error()
        {
            ErrorResult errorResult = _errorHandler.GetError();

            return new ObjectResult(errorResult)
            {
                StatusCode = errorResult.Error.Status,
            };
        }

        protected IActionResult Error(HttpErrorBase httpErrorBase)
        {
            var message = new ErrorMessage(httpErrorBase.Id, httpErrorBase.Name);
            var error = new ErrorDetail(httpErrorBase.Status, message, null);
            var errorResult = new ErrorResult(error);

            return new ObjectResult(errorResult)
            {
                StatusCode = httpErrorBase.Status,
            };
        }

        protected bool IsSuccess() => !_errorHandler.HasError();
    }
}
