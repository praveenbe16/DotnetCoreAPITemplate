using DotnetCoreAPITemplate.Common.DTOs;

namespace DotnetCoreAPITemplate.Application.Interfaces
{
    public interface IProductService
    {
        IEnumerable<ProductResponseDto> GetAllProducts();
        ProductResponseDto AddProduct(ProductRequestDto productRequest);
    }
}
