using System;
using System.Collections.Generic;
using FluentValidation.Results;

namespace FileManagement.Application.Exceptions
{
    public class ValidationException : ApplicationException
    {
        public List<string> ValidationErrors { get; }

        public ValidationException(ValidationResult validationResult)
        {
            ValidationErrors = new List<string>();
            foreach (var validationFailure in validationResult.Errors)
            {
                ValidationErrors.Add(validationFailure.ErrorMessage);
            }
        }
    }
}