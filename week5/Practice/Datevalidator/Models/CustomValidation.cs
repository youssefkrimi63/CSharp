using System;
using System.ComponentModel.DataAnnotations;

public class CustomDateValidationAttribute : ValidationAttribute
{
#pragma warning disable CS8765 // Nullability of type of parameter doesn't match overridden member (possibly because of nullability attributes).
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
#pragma warning restore CS8765 // Nullability of type of parameter doesn't match overridden member (possibly because of nullability attributes).
    {
        // Custom validation logic
        DateTime dateValue;

        if (value != null && DateTime.TryParse(value.ToString(), out dateValue))
        {
            if (dateValue < DateTime.Now)
            {
#pragma warning disable CS8603 // Possible null reference return.
                return ValidationResult.Success; // Validation passed
#pragma warning restore CS8603 // Possible null reference return.
            }
            else
            {
                return new ValidationResult("The date must be in the past.");
            }
        }

        return new ValidationResult("Invalid date format or value.");
    }
}
