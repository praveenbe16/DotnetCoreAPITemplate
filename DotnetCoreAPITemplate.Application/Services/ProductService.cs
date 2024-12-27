using DotnetCoreAPITemplate.Common.DTOs;
using DotnetCoreAPITemplate.Application.Interfaces;
using DotnetCoreAPITemplate.Domain.Entities;
using DotnetCoreAPITemplate.Domain.Interfaces;

namespace DotnetCoreAPITemplate.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public IEnumerable<ProductResponseDto> GetAllProducts()
        {
            var products = _productRepository.GetAll();
            return products.Select(p => new ProductResponseDto
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price
            });
        }

        public ProductResponseDto AddProduct(ProductRequestDto productRequest)
        {
            var product = new Product
            {
                Name = productRequest.Name,
                Price = productRequest.Price
            };

            var createdProduct = _productRepository.Add(product);

            return new ProductResponseDto
            {
                Id = createdProduct.Id,
                Name = createdProduct.Name,
                Price = createdProduct.Price
            };
        }
    }
}
