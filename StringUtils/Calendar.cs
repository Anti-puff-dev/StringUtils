using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace StringUtils
{
    public class Calendar
    {
        public static string MetroToMySQL(string date)
        {
            string[] meses = new string[] { "jan", "fev", "mar", "abr", "mai", "jun", "jul", "ago", "set", "out", "nov", "dez" };
            string[] ent = date.ToLower().Split(' ');
            string dia = ent[0];
            string messtr = ent[2];
            int mes = Enumerable.Range(0, meses.Length).Where(index => meses[index].Contains(messtr)).First<int>();
            string ano = ent[4];

            return ano + "-" + StringUtils.Dig.Limit((mes + 1).ToString(), 2) + "-" + StringUtils.Dig.Limit(dia, 2);
        }

        public static string MySQLToMetro(DateTime dt)
        {
            string[] meses = new string[] { "jan", "fev", "mar", "abr", "mai", "jun", "jul", "ago", "set", "out", "nov", "dez" };
            string dia = dt.Day.ToString();
            string mes = meses[(dt.Month - 1)];
            string ano = dt.Year.ToString();
            return dt.Day.ToString() + " de " + mes + " de " + ano;
        }

        public static string FullDateTime(DateTime dt)
        {
            string[] meses = new string[] { "Janeiro", "Fevereiro", "Março", "Abril", "Maio", "Junho", "Julho", "Agosto", "Setembro", "Outubro", "Novembro", "Dezembro" };
            string dia = dt.Day.ToString();
            string mes = meses[(dt.Month - 1)];
            string ano = dt.Year.ToString();
            string hora = dt.Hour.ToString();
            string minuto = dt.Minute.ToString();
            return dt.Day.ToString() + " de " + mes + " de " + ano + " as " + hora + ":" + minuto;
        }

        public static string FullDateTimeD(DateTime dt)
        {
            string[] meses = new string[] { "Janeiro", "Fevereiro", "Março", "Abril", "Maio", "Junho", "Julho", "Agosto", "Setembro", "Outubro", "Novembro", "Dezembro" };
            string dia = dt.Day.ToString();
            string mes = meses[(dt.Month - 1)];
            string ano = dt.Year.ToString();
            string hora = dt.Hour.ToString();
            string minuto = dt.Minute.ToString();
            return dt.Day.ToString() + " de " + mes + " de " + ano;
        }

        public static DateTime JsonDateToDateTime(string d)
        {
            string[] d1 = d.Split(new char[] { ' ', '\t' });
            string[] d2 = d1[0].Split(new char[] { '/' });

            return Convert.ToDateTime(d2[2] + "-" + d2[0] + "-" + d2[1] + " " + d1[1]);
        }

        public static double DateDiff(string howtocompare, System.DateTime startDate, System.DateTime endDate)
        {
            System.TimeSpan TS = new System.TimeSpan(startDate.Ticks - endDate.Ticks);

            double diff = 0;

            switch (howtocompare.ToLower())
            {
                case "m":
                    diff = Convert.ToDouble(TS.TotalMinutes);
                    break;

                case "s":
                    diff = Convert.ToDouble(TS.TotalSeconds);
                    break;

                case "t":
                    diff = Convert.ToDouble(TS.Ticks);
                    break;

                case "mm":
                    diff = Convert.ToDouble(TS.TotalMilliseconds);
                    break;

                case "yyyy":
                    diff = Convert.ToDouble(TS.TotalDays / 365);
                    break;

                case "q":
                    diff = Convert.ToDouble((TS.TotalDays / 365) / 4);
                    break;

                case "d":
                    diff = Convert.ToDouble(TS.TotalDays);
                    break;

                default:
                    diff = Convert.ToDouble(TS.TotalDays);
                    break;

            }

            return diff;
        }
    }
}
