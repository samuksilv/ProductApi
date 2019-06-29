using System.ComponentModel.DataAnnotations;

namespace Product.api.Domain.Models.User {
    public class Client : User {
        [Required]
        public string Code{ get; set; } 

    }
}