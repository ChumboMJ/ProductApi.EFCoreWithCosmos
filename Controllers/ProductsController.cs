using Microsoft.AspNetCore.Mvc;
using ProductApi.EFCoreWithCosmos.Interfaces;
using ProductApi.EFCoreWithCosmos.Models;

namespace CosmosDbEfCoreDemo.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Add(Product product)
        {
            var result = await _productService.AddProductAsync(product);

            return Ok(result);
        }

        [HttpGet("{productId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(Guid productId)
        {
            if (productId == Guid.Empty) return BadRequest($"{nameof(productId)} is required.");

            var product = await _productService.GetProductByIdAsync(productId);

            if (product == null) return NotFound();

            return Ok(product);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update(Product product)
        {
            var result = await _productService.UpdateProductAsync(product);

            if (result == null) return BadRequest();

            return Ok(result);
        }

        [HttpDelete("{productId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Delete(Guid productId)
        {
            if (productId == Guid.Empty) return BadRequest($"{nameof(productId)} is required.");

            var result = await _productService.DeleteProductAsync(productId);

            if (!result) return BadRequest();

            return Ok();
        }
    }
}