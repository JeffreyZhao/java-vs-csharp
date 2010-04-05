using System;
using System.Collections.Generic;
using System.Text;

namespace V2.Attributes
{
    public class Person
    {
        [Range(Min = 10, Max = 60)]
        public int Age { get; set; }

        [Range(30, 50)]
        public int Size { get; set; }

        [Regex(@"^\w+@[a-zA-Z_]+?\.[a-zA-Z]{2,3}$")]
        public string Email { get; set; }

        [Validator(typeof(NameValidator))]
        public string Name { get; set; }
    }

    public class NameValidator : IValidator
    {
        public ValidationResult Validate(object value)
        {
            // maybe name cannot equals "Admin"
            throw new NotImplementedException();
        }
    }
}
