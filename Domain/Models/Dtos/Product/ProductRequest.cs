using System;
using System.Linq;
using FluentValidation;
using FluentValidation.Results;
using Newtonsoft.Json;
using Product.api.Domain.Models.Dtos.Product;

namespace Product.api.Domain.Models.Dtos.Product {
    public class ProductRequest : AbstractRequest<ProductRequest> {

        public string Name { get; set; }
        public string Code { get; set; }
        public long Quantity { get; set; }
        public string ExpirationDate { get; set; }

        [JsonIgnore]
        protected override ValidationResult ValidatorResult {
            get {
                return new ProductValidator ().Validate (this);
            }
        }
    }

    internal class ProductValidator : AbstractValidator<ProductRequest> {

        public ProductValidator () {
            RuleFor (x => x.Name).NotEmpty ().Length (1, 100);
            RuleFor (x => x.Code).NotEmpty ().Length (1, 100);
            RuleFor (x => x.Quantity).NotNull ();

            RuleFor (x => x.ExpirationDate)
                .Cascade (CascadeMode.StopOnFirstFailure)
                .NotEmpty ()
                .Must (dateString => DateTime.TryParse (dateString, out DateTime date))
                    .WithMessage ("Date format invalid.")
                .Must (x => DateTime.Parse (x) >= DateTime.Now.Date)
                    .WithMessage ("Can't insert overdue product.");

        }
    }
}