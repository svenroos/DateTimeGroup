using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DateTimeGroup
{
    public class DTG
    {
        public enum DTGTimeZone
        {
            Y, X, W, VSTAR, V, U, T, S, R, Q, PSTAR, P, O, N,
            Z,
            A, B, C, D, DSTAR, E, ESTAR, F, FSTAR, G, H, I, ISTAR, K, KSTAR, L, M, MSTAR,
            J
        }
        private static DTGTimeZoneMap s_dtgTimeZoneMap;
        private static DTGMonthMap s_dtgMonthMap;

        private static int s_century = 2000;

        static DTG()
        {
            s_dtgTimeZoneMap = new DTGTimeZoneMap();
            s_dtgMonthMap = new DTGMonthMap();
        }
        public static string ConvertToDTG(DateTime dateTime)
        {
            return ConvertToDTG(dateTime, DTGTimeZone.Z);
        }
        public static string ConvertToDTG(DateTime dateTime, string dtgTimeZone)
        {
            if (!IsValidTimeZone(dtgTimeZone))
            {
                throw new ArgumentOutOfRangeException(nameof(dtgTimeZone));
            }

            return ConvertToDTG(dateTime, s_dtgTimeZoneMap.TimeZoneForString(dtgTimeZone));
        }

        public static string ConvertToDTG(DateTime dateTime, DTGTimeZone dtgTimeZone)
        {
            double offset;

            if (dtgTimeZone == DTGTimeZone.J)
            {
                offset = TimeZoneInfo.Local.BaseUtcOffset.Hours;
                if (TimeZoneInfo.Local.IsDaylightSavingTime(dateTime))
                {
                    offset = offset + 1.0;
                }
            }
            else
            {
                offset = s_dtgTimeZoneMap.OffsetForTimeZone(dtgTimeZone);
            }

            DateTime dt = dateTime.ToUniversalTime().AddHours(offset);

            return ToDTGString(dt, dtgTimeZone);
        }


        private static string ToDTGString(DateTime dateTime, DTGTimeZone dtgTimeZone)
        {
            string dtg = "";
            dtg = dtg + dateTime.Day.ToString("00");
            dtg = dtg + dateTime.Hour.ToString("00");
            dtg = dtg + dateTime.Minute.ToString("00");
            dtg = dtg + s_dtgTimeZoneMap.StringForTimeZone(dtgTimeZone);
            dtg = dtg + s_dtgMonthMap.StringForMonthIndex(dateTime.Month);
            dtg = dtg + dateTime.Year.ToString().Substring(2);

            return dtg;
        }

        public static DateTime ConvertFromDTGString(string? dtgstring)
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

            dt = new DateTime(s_century + year, s_dtgMonthMap.IndexForMonthName(strmonth), day, hour, minute, 0, DateTimeKind.Utc);

            double offset;

            if (s_dtgTimeZoneMap.TimeZoneForString(strzone) == DTGTimeZone.J)
            {
                offset = TimeZoneInfo.Local.BaseUtcOffset.Hours;
                if (TimeZoneInfo.Local.IsDaylightSavingTime(dt))
                {
                    offset = offset + 1.0;
                }
            }
            else
            {
                offset = s_dtgTimeZoneMap.OffsetForString(strzone);
            }

            dt = dt.AddHours(-offset);

            return true;
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
            if (!s_dtgTimeZoneMap.ContainsString(strzone))
            {
                return false;
            }
            if (!s_dtgMonthMap.ContainsMonthName(strmonth))
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
                DateTime dt = new DateTime(s_century + year, s_dtgMonthMap.IndexForMonthName(strmonth), day, hour, minute, 0, DateTimeKind.Utc);
            }
            catch
            {
                return false;
            }


            return true;
        }



        public static int GetCenturyBase()
        {
            return s_century;
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

        public static bool IsValidTimeZone(string timeZone)
        {
            return s_dtgTimeZoneMap.ContainsString(timeZone);
        }
    }
}
