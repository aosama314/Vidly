using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Min18YearsIfAMember : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Customer)validationContext.ObjectInstance;
            if (customer.MembershipTypeId == MembershipType.Unknown ||
                customer.MembershipTypeId == MembershipType.PayAsYouGo)
            {
                return ValidationResult.Success;
            }
            if (customer.BirthDate == null)
                return new ValidationResult("BirthDate Is Required.");

            var age = DateTime.Now.Year - customer.BirthDate.Value.Year;
            return (age >= 18) 
                ? ValidationResult.Success 
                : new ValidationResult("Customer Is Younger Than 18 Years Old.");
        }
    }
}