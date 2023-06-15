namespace WebApi.Infrastructure.Errors
{
    public class ErrorResult
    {
        public ErrorResult(ErrorDetail error)
        {
            Error = error;
        }

        public ErrorDetail Error { get; }
    }
}
