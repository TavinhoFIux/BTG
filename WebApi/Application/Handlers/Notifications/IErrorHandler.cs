using FluentValidation.Results;
using WebApi.Application.Commands;
using WebApi.Infrastructure.Errors;

namespace WebApi.Application.Handlers.Notifications
{
    public interface IErrorHandler
    {
        bool ValidateCommand(Command command);

        void Add(ValidationResult validationResult);

        void Add(HttpErrorBase httpError);

        bool HasError();

        /// <summary>
        /// Calling this method without an error it will throw an <see cref="InvalidOperationException"/>,
        /// so always call the <see cref="HasError()"/> before it.
        /// </summary>
        /// <returns></returns>
        /// 
        ErrorResult GetError();
    }
}
