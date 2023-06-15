namespace WebApi.Infrastructure.Errors
{
    public class ErrorDetail
    {
        public ErrorDetail(int status, ErrorMessage message, List<ErrorItem>? errors)
        {
            Status = status;
            Message = message;
            Errors = errors;
        }

        public int Status { get; }
        public ErrorMessage Message { get; }
        public List<ErrorItem>? Errors { get; }
    }
}
