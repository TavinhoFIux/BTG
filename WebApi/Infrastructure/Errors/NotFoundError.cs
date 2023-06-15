namespace WebApi.Infrastructure.Errors
{
    public class ErrorValidate : HttpErrorBase
    {
        public static readonly ErrorValidate FailCreateProduct = new(
            "failcreateproduct", "Falha ao criar produto");

        public static readonly ErrorValidate FailDeleteProduct = new(
          "faildeleteproduct", "Falha ao deletar produto");

        public static readonly ErrorValidate FailEditProduct = new(
             "faileditproduct", "Falha ao edit produto");


        public ErrorValidate(string id, string name) : base(id, name, StatusCodes.Status404NotFound)
        {
        }
    }
}
