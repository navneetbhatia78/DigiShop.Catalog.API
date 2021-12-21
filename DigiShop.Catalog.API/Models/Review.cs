using System;
using System.Collections.Generic;

namespace DigiShop.Catalog.API.Models
{
    public partial class Review
    {
        public int FeedbackId { get; set; }
        public int? UserId { get; set; }
        public int? OrderId { get; set; }
        public int? ProductId { get; set; }
        public string ReviewDescription { get; set; }
        public int Rating { get; set; }
        public string CreatedDate { get; set; }
        public int CreatedUserId { get; set; }
        public string ModifiedDate { get; set; }
        public int? ModifiedUserId { get; set; }

        public virtual Product Product { get; set; }
    }
}
