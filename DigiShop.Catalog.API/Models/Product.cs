using System;
using System.Collections.Generic;

namespace DigiShop.Catalog.API.Models
{
    public partial class Product
    {
        public Product()
        {
            Review = new HashSet<Review>();
        }

        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int? CategoryId { get; set; }
        public int? BrandId { get; set; }
        public float Price { get; set; }
        public string Description { get; set; }
        public string Size { get; set; }
        public string ImagePath { get; set; }
        public int SellerId { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedUserId { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int? ModifiedUserId { get; set; }

        public virtual Brand Brand { get; set; }
        public virtual Category Category { get; set; }
        public virtual ICollection<Review> Review { get; set; }
    }
}
