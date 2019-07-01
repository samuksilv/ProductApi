using System;
using System.ComponentModel.DataAnnotations;

namespace Product.api.Domain.Models.Product {
    public class ProductDetails {
            
        public long Quantity { get; set; } 

        [Required]
        public DateTime ExpirationDate { get; set; }
    }
}