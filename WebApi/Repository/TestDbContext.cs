using Bogus;
using Microsoft.EntityFrameworkCore;
using WebApi.Application.Models;

namespace WebApi.Repository
{
    public class TestDbContext : DbContext
    {
        public TestDbContext(DbContextOptions<TestDbContext> options) : base(options)
        {
        }

        protected TestDbContext() { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Product>().HasData(getProductSeed());
        }

        private Product[] getProductSeed()
        {
            List<Product> result = new();
            for (int id = 0; id < 20; id++)
            {
                result.Add(new Product(id + 1, new Faker().Commerce.ProductName()));
            }
            return result.ToArray();
        }

        public DbSet<Product> Products { get; set; }
    }
}
