using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MovieRental.Models
{
    public class CustomerCustomValidation : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var Customer = (Customer)validationContext.ObjectInstance;

            if (Customer.MembershipTypeId == MembershipType.unknown || Customer.MembershipTypeId ==MembershipType.PayasyouGo)
            {
                return ValidationResult.Success;
            }

            if(Customer.DateOfBirth == null)
            {
                return new ValidationResult("Date of Birth is required");
            }
            var age = DateTime.Now.Year - Customer.DateOfBirth.Value.Year;

            if(age >= 18)
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult("Customer must be 18 years old");
            }
        }
    }
}