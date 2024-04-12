using System.ComponentModel.DataAnnotations;


public class oddNumber : ValidationAttribute
{
#pragma warning disable CS8765 // Nullability of type of parameter doesn't match overridden member (possibly because of nullability attributes).

    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
#pragma warning restore CS8765 // Nullability of type of parameter doesn't match overridden member (possibly because of nullability attributes).

    {
        int number;

        if (value == null || !int.TryParse(value.ToString(), out number))
        {
            // Validation failed for non-integer values
            return new ValidationResult("Invalid number format or value.");
        }

        if (number % 2 != 1)
        {
            return new ValidationResult("The number must be an odd number.");
        }

        // Validation passed
#pragma warning disable CS8603 // Possible null reference return.

        return ValidationResult.Success;
#pragma warning restore CS8603 // Possible null reference return.

    }
}