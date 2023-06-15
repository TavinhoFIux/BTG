namespace WebApi.Infrastructure.Errors
{
    public class ErrorMessage
    {
        public ErrorMessage(string code, string description) 
        {
            Code = code;
            Description = description;  
        }

        public static ErrorMessage Empty { get; }
        public string Code { get; }
        public string Description { get; }
    }
}
