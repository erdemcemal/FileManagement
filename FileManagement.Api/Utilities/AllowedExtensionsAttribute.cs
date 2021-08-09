using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.IO;
using Microsoft.AspNetCore.Http;

namespace FileManagement.Api.Utilities
{
    public class AllowedExtensionsAttribute : ValidationAttribute
    {
        private readonly string[] _permittedExtensions = {".txt", ".pdf"};
       
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is not IFormFile file) return ValidationResult.Success;
            var extension = Path.GetExtension(file.FileName);
            return !((IList) _permittedExtensions).Contains(extension.ToLower()) 
                ? new ValidationResult(GetErrorMessage()) 
                : ValidationResult.Success;
        }
    
        public string GetErrorMessage()
        {
            return $"This photo extension is not allowed!";
        }
    }
}