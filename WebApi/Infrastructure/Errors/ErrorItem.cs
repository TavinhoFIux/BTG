namespace WebApi.Infrastructure.Errors
{
    public partial class ErrorItem
    {
        public ErrorItem(string reason, string message)
        {
            Reason = reason;
            Message = message;
        }

        public string Reason { get; }
        public string Message { get; }
    }
}
