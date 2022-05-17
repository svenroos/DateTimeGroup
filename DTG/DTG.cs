using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DateTimeGroup
{
    public static class DTG
    {
        private static Dictionary<int, string> monthindexname = new Dictionary<int, string>();
        private static Dictionary<string, int> monthnameindex = new Dictionary<string, int>();
        private static Dictionary<string, double> timezonelettertooffset = new Dictionary<string, double>();

        private static int century = 2000;

        static DTG()
        {
            monthindexname.Add(1, "JAN");
            monthindexname.Add(2, "FEB");
            monthindexname.Add(3, "MAR");
            monthindexname.Add(4, "APR");
            monthindexname.Add(5, "MAY");
            monthindexname.Add(6, "JUN");
            monthindexname.Add(7, "JUL");
            monthindexname.Add(8, "AUG");
            monthindexname.Add(9, "SEP");
            monthindexname.Add(10, "OCT");
            monthindexname.Add(11, "NOV");
            monthindexname.Add(12, "DEC");

            monthnameindex.Add("JAN", 1);
            monthnameindex.Add("FEB", 2);
            monthnameindex.Add("MAR", 3);
            monthnameindex.Add("APR", 4);
            monthnameindex.Add("MAY", 5);
            monthnameindex.Add("JUN", 6);
            monthnameindex.Add("JUL", 7);
            monthnameindex.Add("AUG", 8);
            monthnameindex.Add("SEP", 9);
            monthnameindex.Add("OCT", 10);
            monthnameindex.Add("NOV", 11);
            monthnameindex.Add("DEC", 12);

            timezonelettertooffset.Add("Y", -12.0);
            timezonelettertooffset.Add("X", -11.0);
            timezonelettertooffset.Add("W", -10.0);
            timezonelettertooffset.Add("V", -9.0);
            timezonelettertooffset.Add("U", -8.0);
            timezonelettertooffset.Add("T", -7.0);
            timezonelettertooffset.Add("S", -6.0);
            timezonelettertooffset.Add("R", -5.0);
            timezonelettertooffset.Add("Q", -4.0);
            timezonelettertooffset.Add("P*", -3.5);
            timezonelettertooffset.Add("P", -3.0);
            timezonelettertooffset.Add("O", -2.0);
            timezonelettertooffset.Add("N", -1.0);
            timezonelettertooffset.Add("Z", 0.0);
            timezonelettertooffset.Add("A", 1.0);
            timezonelettertooffset.Add("B", 2.0);
            timezonelettertooffset.Add("C", 3.0);
            timezonelettertooffset.Add("D", 4.0);
            timezonelettertooffset.Add("D*", 4.5);
            timezonelettertooffset.Add("E", 5.0);
            timezonelettertooffset.Add("F", 6.0);
            timezonelettertooffset.Add("G", 7.0);
            timezonelettertooffset.Add("H", 8.0);
            timezonelettertooffset.Add("I", 9.0);
            timezonelettertooffset.Add("K", 10.0);
            timezonelettertooffset.Add("L", 11.0);
            timezonelettertooffset.Add("M", 12.0);
            timezonelettertooffset.Add("M*", 13.0);


        }

        public static string AsDTG(DateTime dt)
        {
            string dtg = "";
            dtg = dtg + dt.Day.ToString("00");
            dtg = dtg + dt.Hour.ToString("00");
            dtg = dtg + dt.Minute.ToString("00");
            dtg = dtg + "Z";
            dtg = dtg + GetMonthName(dt.Month);
            dtg = dtg + dt.Year.ToString().Substring(2);

            return dtg;
        }

        public static DateTime FromString(string? dtgstring)
        {
            if (string.IsNullOrEmpty(dtgstring))
            {
                throw new ArgumentNullException("String is empty or null");
            }

            DateTime dt = new DateTime();

            if (!ConvertToDateTime(dtgstring, out dt))
            {
                throw new ArgumentOutOfRangeException("String is not a valid DTG");
            }
            else
            {
                return dt;
            }
        }

        public static bool IsValidDTG(string? dtgstring)
        {
            if (string.IsNullOrEmpty(dtgstring))
            {
                return false;
            }
            if (dtgstring.Length < 12)
            {
                return false;
            }

            string strday = dtgstring.Substring(0, 2);
            string strhour = dtgstring.Substring(2, 2);
            string strminute = dtgstring.Substring(4, 2);
            string strzone = dtgstring.Substring(6, dtgstring.Length - 11);
            string strmonth = dtgstring.Substring(dtgstring.Length - 5, 3);
            string stryear = dtgstring.Substring(dtgstring.Length - 2, 2);

            int day = -1;
            if (!Int32.TryParse(strday, out day))
            {
                return false;
            }
            int hour = -1;
            if (!Int32.TryParse(strhour, out hour))
            {
                return false;
            }
            int minute = -1;
            if (!Int32.TryParse(strminute, out minute))
            {
                return false;
            }
            if (!timezonelettertooffset.ContainsKey(strzone))
            {
                return false;
            }
            if (!monthnameindex.ContainsKey(strmonth))
            {
                return false;
            }
            int year = -1;
            if (!Int32.TryParse(stryear, out year))
            {
                return false;
            }

            try
            {
                DateTime dt = new DateTime(century + year, monthnameindex[strmonth], day, hour, minute, 0, DateTimeKind.Utc);
            }
            catch
            {
                return false;
            }


            return true;
        }

        private static bool ConvertToDateTime(string dtgstring, out DateTime dt)
        {
            if (!IsValidDTG(dtgstring))
            {
                dt = DateTime.MinValue;
                return false;
            }

            int day = Int32.Parse(dtgstring.Substring(0, 2));
            int hour = Int32.Parse(dtgstring.Substring(2, 2));
            int minute = Int32.Parse(dtgstring.Substring(4, 2));
            string strzone = dtgstring.Substring(6, dtgstring.Length - 11);
            string strmonth = dtgstring.Substring(dtgstring.Length - 5, 3);
            int year = Int32.Parse(dtgstring.Substring(dtgstring.Length - 2, 2));

            dt = new DateTime(century + year, monthnameindex[strmonth], day, hour, minute, 0, DateTimeKind.Utc);

            double offset = timezonelettertooffset[strzone];
            dt = dt.AddHours(-offset);

            return true;
        }

        private static string GetMonthName(int monthindex)
        {
            if (!monthindexname.ContainsKey(monthindex))
            {
                throw new KeyNotFoundException("Invalid index for month");
            }

            return monthindexname[monthindex];
        }

        public static int GetCenturyBase()
        {
            return century;
        }

        public static void SetCenturyBase(int newcentury)
        {
            string strnc = newcentury.ToString();

            if (strnc.Length != 4)
            {
                throw new ArgumentOutOfRangeException("Century not valid (has to be e.g. '1900' or '2000' or '2100' etc.");
            }

            if (strnc.Substring(strnc.Length - 2, 2) != "00")
            {
                throw new ArgumentOutOfRangeException("Century not valid (has to be e.g. '1900' or '2000' or '2100' etc.");
            }

        }
    }
}
