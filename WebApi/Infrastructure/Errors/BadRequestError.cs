namespace WebApi.Infrastructure.Errors
{
    public class BadRequestError : HttpErrorBase
    {
        public static readonly BadRequestError InvalidFields = new("invalidfields", "There are some invalid fields");

        public BadRequestError(string id, string name) : base(id, name, StatusCodes.Status400BadRequest) { }
    }
}
