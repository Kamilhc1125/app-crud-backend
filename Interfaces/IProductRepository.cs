using api.Dtos.Product;
using api.Models;

namespace api.Interfaces
{
    public interface IProductRepository
    {
        Task<List<Product>> GetAllProductsAsync();
        Task<List<Product>> GetAllProductsWithCategoriesAsync();
        Task<Product?> GetProductByIdAsync(int id);
        Task<Product> CreateProductAsync(Product product);
        Task<Product?> UpdateProductAsync(int id, UpdateProductDto productDto);
        Task<Product?> DeleteProductAsync(int id);
        bool ProductExist(int id);

        
    }
}