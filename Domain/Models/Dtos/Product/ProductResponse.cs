using System;
using Product.api.Domain.Models.Product;

namespace Product.api.Domain.Models.Dtos.Product {
    public class ProductResponse : AbstractResponse {

        public string Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public ProductDetails Details { get; set; }

        public static explicit operator ProductResponse (Models.Product.Product model) {
            return new ProductResponse {
                Id = model.Id.ToString (),
                    Name = model.Name,
                    Code = model.Code,
                    Details = model.Details
            };
        }
    }
}