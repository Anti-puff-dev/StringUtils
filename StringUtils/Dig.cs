using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StringUtils
{
    public class Dig
    {
        public static string Limit(String t, Int32 n)
        {
            if (t.Length < n)
            {
                while (t.Length < n)
                {
                    t = "0" + t;
                }
            }
            else
            {
                t = t.Substring(t.Length - n, n);
            }

            return t;
        }

        public static string IsNaN(string txt)
        {
            try
            {
                string a = Convert.ToInt32(txt).ToString();
                return a;
            }
            catch (Exception err)
            {
                err.ToString();

                return "0";
            }

            return txt;
        }

        public static Int32 Rand(Int32 ini, Int32 fim)
        {
            Random rnd = new Random();
            return rnd.Next(ini, fim);
        }
    }
}
