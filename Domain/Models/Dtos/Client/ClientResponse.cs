using System;
using Product.api.Domain.Models.User;

namespace ProductApi.Domain.Models.Dtos.Client
{
    public class ClientResponse
    {
        public string Id { get; set; }
        public string Code { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string FullName { get; set; }    
        public DateTime DateOfBirth { get; set; }

        public static explicit operator ClientResponse(Product.api.Domain.Models.User.Client client)
        {
            return new ClientResponse
            {
                Id = client.Id.ToString(),
                Code = client.Code,
                Username= client.Username,
                Email= client.Email,
                Phone= client.Phone,
                FullName = $"{client.Name} {client.LastName }",
                DateOfBirth= client.DateOfBirth
            };
        }
    }
}