namespace api.Dtos.Product
{
    public class ProductCategoryDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public decimal Price { get; set; }
        public string? CategoryName { get; set; }
    }
}