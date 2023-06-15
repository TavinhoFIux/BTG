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
            for (int i = 0; i < 20; i++)
            {
                result.Add(new Product()
                {
                    Id = i + 1,
                    Name = new Faker().Commerce.ProductName()
                });
            }
            return result.ToArray();
        }

        public DbSet<Product> Products { get; set; }
    }
}
