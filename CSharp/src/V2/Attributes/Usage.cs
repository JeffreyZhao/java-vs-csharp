using System;
using System.Collections.Generic;
using System.Text;

namespace V2.Attributes
{
    public static class Usage
    {
        public static void Validate(object o)
        {
            var type = o.GetType();
            foreach (var property in type.GetProperties())
            {
                var validateAttrs = (ValidationAttribute[])property.GetCustomAttributes(
                    typeof(ValidationAttribute), true);

                var propValue = property.GetValue(o, null);
                foreach (var attr in validateAttrs)
                {
                    var result = attr.Validate(propValue);
                    // do more things
                }
            }
        }

        public static void AttributeRelatedTest()
        {
            // directly create attribute instances
            var attr = new RangeAttribute(20, 30);

            // pass to some other methods for test
        }
    }
}
