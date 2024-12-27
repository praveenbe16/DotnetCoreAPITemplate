using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using DotnetCoreAPITemplate.Application.Interfaces;
using DotnetCoreAPITemplate.Common.DTOs;
using DotnetCoreAPITemplate.Application.Services;

namespace DotnetCoreAPITemplate.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        [Authorize(Policy = "AdminOnly")]
        public IActionResult GetAllProducts()
        {
            var products = _productService.GetAllProducts();
            return Ok(products);
        }

        [HttpPost]
        public IActionResult AddProduct([FromBody] ProductRequestDto productRequest)
        {
            var product = _productService.AddProduct(productRequest);
            return CreatedAtAction(nameof(GetAllProducts), new { id = product.Id }, product);
        }
    }
}
