using WebApi.Application.Models;

namespace WebApi.Services
{
    public interface IProductService
    {
        Task<List<Product>> GetAllProductAsync();
    }
}
