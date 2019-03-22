using System;
using System.ComponentModel.DataAnnotations;

namespace BillsSystem.Models.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class XorAttribute : ValidationAttribute
    {
        private string targetProp;
        public XorAttribute(string targetProp)
        {
            this.targetProp = targetProp;
        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var targetPropValue = validationContext.ObjectType
                .GetProperty(targetProp)
                .GetValue(validationContext.ObjectInstance);

            if (value == null && targetProp == null ||
                value != null && targetProp != null)
            {
                return new ValidationResult("The two props must have opposite values");
            }
            return ValidationResult.Success;
        }
    }
}
