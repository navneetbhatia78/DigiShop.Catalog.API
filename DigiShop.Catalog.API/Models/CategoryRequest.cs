using System.ComponentModel.DataAnnotations;

namespace DigiShop.Catalog.API.Models
{
    public class CategoryRequest
    {
        [Required(ErrorMessage = "Brand Name is Required")]
        [MaxLength(20, ErrorMessage = "Brand name cannot be greater than 20 characters")]
        public string CategoryName { get; set; }
    }
}