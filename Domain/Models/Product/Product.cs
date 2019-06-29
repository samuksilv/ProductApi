using System.ComponentModel.DataAnnotations;

namespace Product.api.Domain.Models.Product {
    public class Product : BaseModel {
        public string Name { get; set; }
        public string Code { get; set; }

        [Required]
        public ProductDetails Details { get; set; }

    }
}