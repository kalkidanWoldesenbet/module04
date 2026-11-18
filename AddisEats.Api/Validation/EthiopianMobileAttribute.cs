using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace AddisEats.Api.Validation;

public class EthiopianMobileAttribute : ValidationAttribute
{
   private static readonly Regex Pattern = new(@"^(\+251|0)?9\d{8}$", RegexOptions.Compiled);

    public EthiopianMobileAttribute()
    {
        ErrorMessage = "Enter a valid Ethiopian mobile number (e.g., +251912345678 or 0912345678).";
    }
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        //required is responsible for checking null or empty values, so we can skip that here
        if (value is null)
        {
            return ValidationResult.Success;
        }
        if(value is not string phone|| !Pattern.IsMatch(phone))
        {
            return new ValidationResult(ErrorMessage);
        }
        return ValidationResult.Success;
    }
}