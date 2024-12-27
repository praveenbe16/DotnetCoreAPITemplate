using DotnetCoreAPITemplate.Domain.Entities;
using DotnetCoreAPITemplate.Domain.Interfaces;

namespace DotnetCoreAPITemplate.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly List<Product> _products = new List<Product>();

        public IEnumerable<Product> GetAll() => _products;

        public Product Add(Product product)
        {
            product.Id = _products.Count + 1;
            _products.Add(product);
            return product;
        }
    }
}
