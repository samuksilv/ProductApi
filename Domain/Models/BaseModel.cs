using System;

namespace Product.api.Domain.Models {
    public class BaseModel {
        public Guid Id { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public DateTime? DeleteDate { get; set; }

    }
}