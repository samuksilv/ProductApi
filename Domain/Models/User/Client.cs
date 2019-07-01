using System;
using System.ComponentModel.DataAnnotations;
using ProductApi.Domain.Models.Dtos.Client;

namespace Product.api.Domain.Models.User
{
    public class Client : User
    {
        [Required]
        public string Code { get; set; }

        public static explicit operator Client(ClientRequest model)
        {
            return new Client
            {
                Name = model.Name,
                LastName = model.LastName,
                Phone = model.Phone,
                DateOfBirth = DateTime.Parse(model.DateOfBirth),
                Code= model.Code,
                Email= model.Email,
                Username= model.Username
            };
        }
    }
}