using System.ComponentModel.DataAnnotations;

namespace AddisEats.Api.Validation;

public class ETBAmountAttribute : ValidationAttribute
{
    public ETBAmountAttribute()
    {
        ErrorMessage = "Total amount must be a positive decimal value.";
    }

    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (value is null)
        {
            return ValidationResult.Success;
        }

        if (value is not decimal amount || amount <= 0m)
        {
            return new ValidationResult("Total amount must be a positive decimal value.");
        }
        if (decimal.Round(amount, 2) != amount)
        {
            return new ValidationResult("Total amount must have at most two decimal places.");
		}

		return ValidationResult.Success;
    }
}