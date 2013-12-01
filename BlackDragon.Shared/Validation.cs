using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackDragon.Shared
{
    public class Validation
    {
        public static bool IsStringNullOrEmpty(object obj)
        {
            return obj == null || string.IsNullOrEmpty(obj.ToString());
        }
    }
}
