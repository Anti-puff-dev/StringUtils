using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace StringUtils
{
    public class Optimize
    {
        public static string CaseMode(String txt)
        {
            string result = "";

            if (txt != "" && !String.IsNullOrEmpty(txt))
            {
                String[] elements = txt.Split(new char[] { ' ' });
                for (int i = 0; i < elements.Length; i++)
                {
                    if (elements[i].Length > 0)
                    {
                        if (elements[i].ToLower() != "de" && elements[i].ToLower() != "da" && elements[i].ToLower() != "do" && elements[i].ToLower() != "dos" && elements[i].ToLower() != "das" && elements[i].ToLower() != "e")
                        {
                            string p1 = elements[i].Substring(0, 1);
                            string p2 = elements[i].Substring(1);

                            elements[i] = p1.ToUpper() + p2.ToLower();
                        }
                        else
                        {
                            elements[i] = elements[i].ToLower();
                        }
                    }
                }

                result = String.Join(" ", elements);
            }

            return result;
        }

        public static string StripTags(string source)
        {
            return Regex.Replace(source, "<.*?>", string.Empty);
        }


        public static string Sanitize(string txt)
        {
            string[] sqlCheckList = { "--", ";--", ";", "/*", "*/", "@@", "@", "char", "nchar", "varchar", "nvarchar", "alter", "begin", "cast", "create", "cursor", "declare", "delete", "drop", "end", "exec", "execute", "fetch", "insert", "kill", "select", "sys", "sysobjects", "syscolumns", "table", "update" };
            foreach(string s in sqlCheckList)
            {
                txt = txt.Replace(s, "");
            }
            return txt;
        }
    }
}
