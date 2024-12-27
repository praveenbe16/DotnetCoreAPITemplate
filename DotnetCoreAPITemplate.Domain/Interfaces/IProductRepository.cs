using DotnetCoreAPITemplate.Domain.Entities;

namespace DotnetCoreAPITemplate.Domain.Interfaces
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAll();
        Product Add(Product product);
    }
}
