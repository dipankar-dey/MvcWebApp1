using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyFirstMVCWebApp.Models
{
    public class Min18YearsMembership : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Customer)validationContext.ObjectInstance;
            if (customer.MembershipTypeId<=1)
            {
                return ValidationResult.Success;
            }

            if (customer.BirthDate == null)
            {
                return new ValidationResult("Please enter Birthdate");

            }

            var age = DateTime.Today.Year - customer.BirthDate.Value.Year;

            return (age >=18)
                ? ValidationResult.Success 
                : new ValidationResult("Customer should be atleast 18 Years!"); 
        }
    }
}