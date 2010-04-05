using System;
using System.Collections.Generic;
using System.Text;

namespace V2.Attributes
{
    public class RangeAttribute : ValidationAttribute
    {
        public RangeAttribute() { }

        public RangeAttribute(int min, int max)
        {
            this.Min = min;
            this.Max = max;
        }

        public int Min { get; set; }

        public int Max { get; set; }

        public override ValidationResult Validate(object value)
        {
            throw new NotImplementedException();
        }
    }
}
