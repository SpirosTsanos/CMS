using System.Globalization;
using System.Text.RegularExpressions;
using System.Windows.Controls;

namespace CMS.NewClient.AddressInfo
{
    public class AddressNumberValidator : ValidationRule
    {
        public int MinSize { get; set; } = 3;

        public int MaxSize { get; set; } = 5;

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            var input = value as string;
            if (string.IsNullOrWhiteSpace(input))
                return new ValidationResult(false, "Address Number is required");
            if (input.Length < MinSize)
                return new ValidationResult(false, $"Address Number needs to be at least {MinSize} characters");
            if (input.Length > MaxSize)
                return new ValidationResult(false, $"Address Number needs to be under {MaxSize} characters");
            if (!Regex.IsMatch(input, @"^[0-9 ]+$"))
                return new ValidationResult(false, $"Can only contain numbers and spaces");

            return ValidationResult.ValidResult;
        }
    }
}
