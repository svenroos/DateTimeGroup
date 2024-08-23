using System;
using System.Collections.Generic;


namespace DateTimeGroupExtension
    {
    /// <summary>
    /// DateTimeExtension extends DateTime struct
    /// </summary>
    public static class DateTimeExtension
    {
        /// <summary>
        /// Returns string in DTG format for TimeZone "Z"
        /// </summary>
        public static string ToDTGString(this DateTime dateTime)
        {
            return DateTimeGroup.ConvertToDateTimeGroup(dateTime);
        }

        /// <summary>
        /// Returns string in DTG format
        /// </summary>
        /// <param name="timeZone">The TimeZone for which DTG string is returned</param>
        public static string ToDTGString(this DateTime dateTime, string timeZone)
        {
            if (!DateTimeGroup.IsValidTimeZone(timeZone))
            {
                throw new ArgumentOutOfRangeException(timeZone, "Not a valid timezone");
            }

            return DateTimeGroup.ConvertToDateTimeGroup(dateTime, timeZone);
        }

        /// <summary>
        /// Returns a datetime for a DTG string
        /// </summary>
        /// <param name="dtgString">The string in DTG format</param>
        public static DateTime FromDTGString(string dtgString)
        {
            if (string.IsNullOrEmpty(dtgString))
            {
                throw new ArgumentNullException(dtgString);
            }

            if (!DateTimeGroup.IsValidDTG(dtgString))
            {
                throw new ArgumentOutOfRangeException(dtgString, "Not a valid DateTimeGroup");
            }

            return DateTimeGroup.ConvertFromDTGString(dtgString);
        }

        /// <summary>
        /// Returns a list of strings with all timezones
        /// </summary>
        public static List<string> GetTimeZones()
        {
            return DateTimeGroup.GetTimeZones();
        }

        /// <summary>
        /// Returns a list of KeyValue Pairs with all timezones and offsets
        /// </summary>
        public static List<KeyValuePair<string, double>> GetTimeZonesWithOffset()
        {
            return DateTimeGroup.GetTimeZonesWithOffset();
        }
    }
}