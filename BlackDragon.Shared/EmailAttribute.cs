using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace BlackDragon.Shared
{
    /// <summary>
    /// Validate Email format with maxlength 100
    /// </summary>
    public class EmailAttribute : StringLengthAttribute
    {
        public EmailAttribute()
            : base(100)
        {

        }

        private static Regex r = new Regex(@"^[_a-zA-Z0-9-]+(\.[_a-zA-Z0-9-]+)*@[a-zA-Z0-9-]+(\.[a-zA-Z0-9-]+)*(\.[a-zA-Z]{2,3})$");

        public override bool IsValid(object value)
        {
            return base.IsValid(value) && (Validation.IsStringNullOrEmpty(value)) || (r.IsMatch(value.ToString()));
        }

        public override string FormatErrorMessage(string name)
        {
            return string.Format("The {0} is invalid e-mail format.", name.Replace(".", " "));
        }
    }
}
