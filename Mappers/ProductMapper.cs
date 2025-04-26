using api.Dtos.Product;
using api.Models;

namespace api.Mappers
{
    public static class ProductMapper
    {
        public static ProductDto ToProductDto(this Product productModel)
        {
            return new ProductDto
            {
                Id = productModel.Id,
                Name = productModel.Name,
                Price = productModel.Price,
                CategoryId = productModel.CategoryId
            };
        }

        public static ProductCategoryDto ToProductCategoryDto(this Product productModel)
        {
            return new ProductCategoryDto
            {
                Id = productModel.Id,
                Name = productModel.Name,
                Price = productModel.Price,
                CategoryName = productModel.Category?.Name
            };
        }

        public static Product ToProductFromCreateDto(this CreateProductDto productDto)
        {
            return new Product
            {
                Name = productDto.Name,
                Price = productDto.Price,
                CategoryId = productDto.CategoryId
            };
        }
    }
}