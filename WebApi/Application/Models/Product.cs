using Bogus.DataSets;

namespace WebApi.Application.Models
{
    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public Product(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public Product(string name)
        {
            Name = name;
        }
    }
}
