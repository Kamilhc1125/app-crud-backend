using api.Dtos.Product;
using api.Interfaces;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/product")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepo;
        public ProductController(IProductRepository productRepo)
        {
            _productRepo = productRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            var products = await _productRepo.GetAllProductsAsync();

            var productsDto = products.Select(p => p.ToProductDto());

            return Ok(productsDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            if (!_productRepo.ProductExist(id))
            {
                return NotFound();
            }

            var product = await _productRepo.GetProductByIdAsync(id);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(product?.ToProductDto());
        }

        [HttpGet("category")]
        public async Task<IActionResult> GetAllProductsWithCategories()
        {
            var product = await _productRepo.GetAllProductsWithCategoriesAsync();

            var productDto = product.Select(p => p.ToProductCategoryDto());

            return Ok(productDto);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] CreateProductDto productDto)
        {
            if (productDto == null)
            {
                return BadRequest(ModelState);
            }

            var productModel = productDto.ToProductFromCreateDto();

            await _productRepo.CreateProductAsync(productModel);

            return CreatedAtAction(nameof(GetProduct), new { id = productModel.Id }, productModel.ToProductDto());
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateProduct([FromRoute] int id, [FromBody] UpdateProductDto updateDto)
        {
            var product = await _productRepo.UpdateProductAsync(id, updateDto);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product.ToProductDto());

        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteProduct([FromRoute] int id)
        {
            var product = await _productRepo.DeleteProductAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}