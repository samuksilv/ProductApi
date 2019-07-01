using System;
using System.ComponentModel.DataAnnotations;

namespace Product.api.Domain.Models.User {
    public class User : BaseModel {

        [Required]
        public string Username { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }
        
        public string Phone { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }
    }
}