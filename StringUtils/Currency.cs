using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StringUtils
{
    public class Currency
    {
        public static string RealToMySQL(String txt)
        {
            return txt.Replace("R$", "").Replace(" ", "").Replace(".", "").Replace(",", ".");
        }

    }
}
