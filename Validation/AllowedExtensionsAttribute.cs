using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace mvc.Validation
{
    public class AllowedExtensionsAttribute : ValidationAttribute, IClientModelValidator
    {
        private readonly string[] _extensions;

        public AllowedExtensionsAttribute(params string[] extensions)
        {
            _extensions = extensions;
            ErrorMessage = "Недопустимий тип файлу";
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value is IFormFile file)
            {
                var ext = Path.GetExtension(file.FileName).ToLower();
                if (!_extensions.Contains(ext))
                    return new ValidationResult(ErrorMessage);
            }

            return ValidationResult.Success;
        }

        public void AddValidation(ClientModelValidationContext context)
        {
            context.Attributes.TryAdd("data-val", "true");
            context.Attributes.TryAdd("data-val-allowedextensions", ErrorMessage!);
            context.Attributes.TryAdd("data-val-allowedextensions-extensions", string.Join(",", _extensions));
        }
    }
}
