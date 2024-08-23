using System;
using System.Collections.Generic;

namespace DateTimeGroupExtension
{
    public class DateTimeGroup
    {

        private readonly static DateTimeGroupTimeZones s_dtgTimeZoneMap;
        private readonly static DateTimeGroupMonths s_dtgMonthMap;

        private readonly static int s_century = 2000;

        static DateTimeGroup()
        {
            s_dtgTimeZoneMap = new DateTimeGroupTimeZones();
            s_dtgMonthMap = new DateTimeGroupMonths();
        }
        public static string ConvertToDateTimeGroup(DateTime dateTime)
        {
            return ConvertToDateTimeGroup(dateTime, "Z");
        }
        public static string ConvertToDateTimeGroup(DateTime dateTime, string dtgTimeZone)
        {
            if (string.IsNullOrEmpty(dtgTimeZone))
            {
                throw new ArgumentNullException(dtgTimeZone, "String is empty or null");
            }

            if (!IsValidTimeZone(dtgTimeZone))
            {
                throw new ArgumentOutOfRangeException(dtgTimeZone, "String is not a valid TimeZone");
            }

            double offset;

            if (dtgTimeZone == "J")
            {
                offset = TimeZoneInfo.Local.BaseUtcOffset.Hours;
                if (TimeZoneInfo.Local.IsDaylightSavingTime(dateTime))
                {
                    offset ++;
                }
            }
            else
            {
                offset = s_dtgTimeZoneMap.OffsetForString(dtgTimeZone);
            }

            DateTime dt = dateTime.ToUniversalTime().AddHours(offset);

            return ToDateTimeGroupString(dt, dtgTimeZone);
        }

        private static string ToDateTimeGroupString(DateTime dateTime, string dtgTimeZone)
        {
            string dtg = "";
            dtg += dateTime.Day.ToString("00");
            dtg += dateTime.Hour.ToString("00");
            dtg += dateTime.Minute.ToString("00");
            dtg += dtgTimeZone;
            dtg += s_dtgMonthMap.StringForMonthIndex(dateTime.Month);
            dtg += dateTime.Year.ToString()[2..];

            return dtg;
        }

        internal static DateTime ConvertFromDTGString(string? dtgstring)
        {
            if (string.IsNullOrEmpty(dtgstring))
            {
                throw new ArgumentNullException(dtgstring, "String is empty or null");
            }

            if (!ConvertToDateTime(dtgstring, out DateTime dt))
            {
                throw new ArgumentOutOfRangeException(dtgstring, "String is not a valid DTG");
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

            int day = Int32.Parse(dtgstring[0..2]);
            int hour = Int32.Parse(dtgstring[2..4]);
            int minute = Int32.Parse(dtgstring[4..6]);
            string strzone = dtgstring[6..^5];
            string strmonth = dtgstring[^5..^2];
            int year = Int32.Parse(dtgstring[^2..]);

            dt = new DateTime(s_century + year, s_dtgMonthMap.IndexForMonthName(strmonth), day, hour, minute, 0, DateTimeKind.Utc);

            double offset;

            if (strzone == "J")
            {
                offset = TimeZoneInfo.Local.BaseUtcOffset.Hours;
                if (TimeZoneInfo.Local.IsDaylightSavingTime(dt))
                {
                    offset++;
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

            int length = dtgstring.Length;

            if (length < 12)
            {
                return false;
            }

            string strday = dtgstring[0..2];
            string strhour = dtgstring[2..4];
            string strminute = dtgstring[4..6];
            string strzone = dtgstring[6..^5];
            string strmonth = dtgstring[^5..^2];
            string stryear = dtgstring[^2..];

            if (!Int32.TryParse(strday, out int day))
            {
                return false;
            }
            if (!Int32.TryParse(strhour, out int hour))
            {
                return false;
            }

            if (!Int32.TryParse(strminute, out int minute))
            {
                return false;
            }
            if (!s_dtgTimeZoneMap.ExistsTimeZone(strzone))
            {
                return false;
            }
            if (!s_dtgMonthMap.IsValidMonthName(strmonth))
            {
                return false;
            }
            if (!Int32.TryParse(stryear, out int year))
            {
                return false;
            }

            try
            {
#if NET5_0_OR_GREATER
                DateTime dt = new(s_century + year, s_dtgMonthMap.IndexForMonthName(strmonth), day, hour, minute, 0, DateTimeKind.Utc);
#else
                DateTime dt = new DateTime(s_century + year, s_dtgMonthMap.IndexForMonthName(strmonth), day, hour, minute, 0, DateTimeKind.Utc);
#endif

            }
            catch
            {
                return false;
            }


            return true;
        }
        public static bool IsValidTimeZone(string timeZone)
        {
            return s_dtgTimeZoneMap.ExistsTimeZone(timeZone);
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
                throw new ArgumentOutOfRangeException(newcentury.ToString(), "Century not valid (has to be e.g. '1900' or '2000' or '2100' etc.");
            }

            if (strnc.Substring(strnc.Length - 2, 2) != "00")
            {
                throw new ArgumentOutOfRangeException(newcentury.ToString(), "Century not valid (has to be e.g. '1900' or '2000' or '2100' etc.");
            }

        }

        internal static List<string> GetTimeZones()
        {
            return s_dtgTimeZoneMap.GetTimeZones();
        }

        internal static List<KeyValuePair<string, double>> GetTimeZonesWithOffset()
        {
            return s_dtgTimeZoneMap.GetTimeZonesWithOffset();
        }
    }
}
