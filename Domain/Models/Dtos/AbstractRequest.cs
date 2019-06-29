using System.Collections.Generic;
using System.Linq;
using FluentValidation;
using FluentValidation.Results;
using Newtonsoft.Json;

namespace Product.api.Domain.Models.Dtos {
    public abstract class AbstractRequest<T> where T : class {

        protected abstract ValidationResult ValidatorResult { get; }

        [JsonIgnore]
        public bool IsValid {
            get {

                return ValidatorResult == null? true : ValidatorResult.IsValid;
            }
        }

        [JsonIgnore]
        public string Erros {
            get {
                if (IsValid) {
                    return null;
                } 
                else {
                    IEnumerable<string> errors = ValidatorResult?.Errors?.Select (x => x.ErrorMessage);
                    if (errors == null) return null;

                    return string.Join (' ', errors);
                }
            }
        }

    }
}