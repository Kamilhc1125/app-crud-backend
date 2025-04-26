namespace api.Dtos.Product
{
    public class UpdateProductDto
    {
        public string? Name { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
    }
}