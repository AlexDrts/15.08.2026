using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace mvc.Validation
{
    public class NotFutureYearAttribute : ValidationAttribute, IClientModelValidator
    {
        public NotFutureYearAttribute()
        {
            ErrorMessage = "Рік не може бути більшим за поточний";
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value is int year && year > DateTime.Now.Year)
                return new ValidationResult(ErrorMessage);

            return ValidationResult.Success;
        }

        public void AddValidation(ClientModelValidationContext context)
        {
            context.Attributes.TryAdd("data-val", "true");
            context.Attributes.TryAdd("data-val-notfutureyear", ErrorMessage!);
            context.Attributes.TryAdd("data-val-notfutureyear-max", DateTime.Now.Year.ToString());
        }
    }
}
