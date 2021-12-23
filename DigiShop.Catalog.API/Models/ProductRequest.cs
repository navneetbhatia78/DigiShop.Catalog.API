using System.ComponentModel.DataAnnotations;

namespace DigiShop.Catalog.API.Models
{
    public class ProductRequest
    {
        [Required(ErrorMessage = "Product Name is Required")]
        [MaxLength(20, ErrorMessage = "Product Name cannot be greater than 20 characters")]
        public string ProductName { get; set; }

        [Required(ErrorMessage = "Category is Required")]
        public int? CategoryId { get; set; }

        [Required(ErrorMessage = "Brand ID is Required")]
        public int? BrandId { get; set; }

        [Required(ErrorMessage = "Price of Product is Required")]
        public float Price { get; set; }

        [Required(ErrorMessage = "Description should be manadatory")]
        [MaxLength(350, ErrorMessage = " Description cannot be greater than 350 chars")]
        public string Description { get; set; }

        public string Size { get; set; }
        public string ImagePath { get; set; }

        [Required(ErrorMessage = "Seller Id Is Required")]
        public int SellerId { get; set; }
    }
}