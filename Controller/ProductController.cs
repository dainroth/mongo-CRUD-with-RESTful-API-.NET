using FinalApi.Models;
using FinalApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace FinalApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly ProductService _productService;

        public ProductController(ProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> Get() =>
            await _productService.GetAllAsync();

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> Get(string id)
        {
            var product = await _productService.GetByIdAsync(id);
            if (product is null)
                return NotFound();
            return product;
        }

        [HttpPost]
        public async Task<IActionResult> Create(Product product)
        {
            await _productService.CreateAsync(product);
            return CreatedAtAction(nameof(Get), new { id = product.Id }, product);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, Product product)
        {
            var existing = await _productService.GetByIdAsync(id);
            if (existing is null)
                return NotFound();

            product.Id = existing.Id;
            await _productService.UpdateAsync(id, product);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var existing = await _productService.GetByIdAsync(id);
            if (existing is null)
                return NotFound();

            await _productService.DeleteAsync(id);
            return NoContent();
        }
    }
}
