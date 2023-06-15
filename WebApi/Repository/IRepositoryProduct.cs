using WebApi.Application.Models;

namespace WebApi.Repository
{
    public interface IRepositoryProduct
    {
        Task<List<Product>> GetAllAsync();

        Product? Get(int id);

        Task AddAsync(Product item);

        Task EditAsync(Product item);

        Task DeleteAsync(int id);
    }
}
