using Microsoft.EntityFrameworkCore;
using WebApi.Application.Models;

namespace WebApi.Repository
{
    public class RepositoryProduct : IRepositoryProduct
    {
        private readonly TestDbContext _ctx;

        public RepositoryProduct(TestDbContext ctx)
        {
            _ctx = ctx;
        }

        public async Task AddAsync(Product item)
        {
            await _ctx.Products.AddAsync(item);

            await _ctx.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            await _ctx.Products.Where(x => x.Id == id).ExecuteDeleteAsync();

            await _ctx.SaveChangesAsync();
        }

        public async Task EditAsync(Product item)
        {
            _ctx.Products.Update(item);

            await _ctx.SaveChangesAsync();
        }

        public Product? Get(int id)
        {
            var products = _ctx.Products.Where(x => x.Id == id).ToList();

            return products.FirstOrDefault();
        }

        public async Task<List<Product>> GetAllAsync()
        {
            var products = await _ctx.Products.OrderBy(x => x.Id).ToListAsync();

            return products;
        }
    }
}
