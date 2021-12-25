namespace DigiShop.Catalog.API.Models
{
    public class ProductResponse
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductImage { get; set; }
        public string ProductBrand { get; set; }
        public string ProductCategory { get; set; }
        public float ProductPrice { get; set; }
    }
}