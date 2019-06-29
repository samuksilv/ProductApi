using System;
using System.ComponentModel.DataAnnotations;
using Product.api.Domain.Models.Dtos.Product;

namespace Product.api.Domain.Models.Product {
    public class Product : BaseModel {
        public string Name { get; set; }
        public string Code { get; set; }

        [Required]
        public ProductDetails Details { get; set; }

        public static explicit operator Product (ProductRequest request) {
            return new Product {
                Name = request.Name,
                Code = request.Code,
                Details = new ProductDetails {
                    Quantity = request.Quantity,
                    ExpirationDate = request.ExpirationDate,
                },
            };
        }
    }
}