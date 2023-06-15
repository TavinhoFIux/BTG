using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebApi.Application.Commands;
using WebApi.Domain.Notifications;
using WebApi.Services;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : MainController
    {
        private readonly IMediator _mediator;
        private readonly IProductService _productService;

        public ProductController(IMediator mediator, IErrorHandler errorHandler, IProductService productService) : base(errorHandler)
        {
            _mediator = mediator;
            _productService = productService;
        }

        [HttpPost()]
        public async Task<IActionResult> CreateProduct(string name)
        {
            var command = new CreateProductCommand(name);
            await _mediator.Send(command);

            if (IsSuccess())
            {
                return Ok();
            }

            return Error();
        }

        [HttpDelete()]
        public async Task<IActionResult> DeleteProduct(int Id)
        {
            var command = new DeleteProductCommand(Id);
            await _mediator.Send(command);

            if (IsSuccess())
            {
                return Ok();
            }

            return Error();
        }

        [HttpPut()]
        public async Task<IActionResult> PutProduct(string name, int Id)
        {
            var command = new EditProductCommand(name, Id);
            await _mediator.Send(command);

            if (IsSuccess())
            {
                return Ok();
            }

            return Error();
        }

        [HttpGet()]
        public async Task<IActionResult> GetAllProduct()
        {
            var products = await _productService.GetAllProductAsync();

            if (IsSuccess())
            {
                return Ok(products);
            }

            return Error();
        }

    }
}
