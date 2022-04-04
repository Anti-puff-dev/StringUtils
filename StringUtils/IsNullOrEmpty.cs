using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StringUtils
{
    public class IsNullOrEmpty
    {
        public static bool Array(String[] arr)
        {
            foreach (string s in arr)
            {
                if (String.IsNullOrEmpty(s)) return true;
            }
            return false;
        }
    }
}
