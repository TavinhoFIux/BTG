using Castle.Core.Resource;
using WebApi.Application.Models;
using WebApi.Repository;

namespace WebApi.Services
{
    public class ProductService : IProductService
    {
        private readonly IRepositoryProduct _repositoryProduct;  

        public ProductService(IRepositoryProduct repositoryProduct)
        {
            _repositoryProduct = repositoryProduct;
        }

        public async Task<List<Product>> GetAllProductAsync()
        {
            List<Product> products = new List<Product>();

            try 
            {
                products = await _repositoryProduct.GetAllAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error buscar a lista de Product", ex);
            }

            return products;
        }

    }
}
