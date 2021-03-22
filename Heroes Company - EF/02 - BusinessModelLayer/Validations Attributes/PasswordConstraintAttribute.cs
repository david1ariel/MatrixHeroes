using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Matrix
{
    public class PasswordConstraintAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null)
                return ValidationResult.Success;

            string regex = "^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[@$!%*?&])[A-Za-z\\d@$!%*?&]{8,}$";

            var match = Regex.Match(value.ToString(), regex);

            if (!match.Success)
            {
                return new ValidationResult("Password must have at least 8 Characters, 1 upper case letter, and 1 special character");
            }

            return ValidationResult.Success;
        }
    }
}
