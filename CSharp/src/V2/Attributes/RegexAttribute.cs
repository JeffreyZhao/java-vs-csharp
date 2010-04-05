using System;
using System.Collections.Generic;
using System.Text;

namespace V2.Attributes
{
    public class RegexAttribute : ValidationAttribute
    {
        public RegexAttribute(string pattern)
        {
            this.Pattern = pattern;
        }

        public string Pattern { get; private set; }

        public override ValidationResult Validate(object value)
        {
            throw new NotImplementedException();
        }
    }
}
