using System;
using FluentValidation;
using FluentValidation.Results;
using Product.api.Domain.Models.Dtos;

namespace ProductApi.Domain.Models.Dtos.Client
{
    public class ClientRequest : AbstractRequest<ClientRequest>
    {
        public string Code{ get; set; }
        public string Username { get; set; }

        public string Email { get; set; }
        public string Phone { get; set; }

        public string Name { get; set; }

        public string LastName { get; set; }

        public string DateOfBirth { get; set; }

        protected override ValidationResult ValidatorResult => new ClientValidator().Validate(this);
    }

    internal class ClientValidator : AbstractValidator<ClientRequest>
    {
        public ClientValidator()
        {
            RuleFor(x => x.Username).NotEmpty();
            RuleFor(x => x.Code).NotEmpty();
            RuleFor(x => x.Email).EmailAddress().NotEmpty();
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.LastName).NotEmpty();
            RuleFor(x => x.LastName).NotEmpty();
            RuleFor(x => x.DateOfBirth)
                           .Cascade(CascadeMode.StopOnFirstFailure)
                           .NotEmpty()
                           .Must(dateString => DateTime.TryParse(dateString, out DateTime date))
                               .WithMessage("Date format invalid.")
                           .Must(x => DateTime.Parse(x) >= DateTime.Now.Date)
                               .WithMessage("please enter a valid date.");
        }
    }
}