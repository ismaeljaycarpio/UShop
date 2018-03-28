using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using UShop.Entities;

namespace UShop.Models
{
    public class Min18YearsIfAMember : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Customer)validationContext.ObjectInstance;

            if (customer.MembershipTypeId == 1 || customer.MembershipTypeId == 0)
                return ValidationResult.Success;

            if (customer.BirthDate == null)
                return new ValidationResult("Birthdate is required"); //instantiate a new validation result

            var age = DateTime.Today.Year - customer.BirthDate.Value.Year;

            return (age >= 18)
                ? ValidationResult.Success
                : new ValidationResult("Customer must be 18 years or older.");
        }
    }
}