namespace DigiShop.Catalog.API.Models
{
    public class ProductDetailDto
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int? CategoryId { get; set; }
        public int? BrandId { get; set; }
        public float Price { get; set; }
        public string Description { get; set; }
        public string Size { get; set; }
        public string ImagePath { get; set; }
        public int SellerId { get; set; }
    }
}