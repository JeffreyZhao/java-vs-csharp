using System;
using System.Collections.Generic;
using System.Text;

namespace V2.Attributes
{
    public interface IValidator
    {
        ValidationResult Validate(object value);
    }

    public class ValidatorAttribute : ValidationAttribute
    {
        public ValidatorAttribute(Type validatorType)
        {
            this.ValidatorType = validatorType;
        }

        public Type ValidatorType { get; private set; }

        public override ValidationResult Validate(object value)
        {
            throw new NotImplementedException();
        }
    }
}
