using System;
using System.Collections.Generic;
using System.Text;

namespace V2.Attributes
{
    public class ValidationResult { }

    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
    public abstract class ValidationAttribute : Attribute
    {
        public abstract ValidationResult Validate(object value);
    }
}
