namespace ZCommerce.Catalog.Dtos.ProductDtos
{
    public class CreateProductDto
    {
        public string CategoryId { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public int ProductStock { get; set; }
        public string ProductDescription { get; set; }
        public string ProductImageUrl { get; set; }
    }
}
