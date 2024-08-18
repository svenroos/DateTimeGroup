using System;

namespace DateTimeGroupExtension
    {
    public static class DateTimeExtension
    {
        public static string ToDTGString(this DateTime dateTime)
        {
            return DateTimeGroup.ConvertToDateTimeGroup(dateTime);
        }

        public static string ToDTGString(this DateTime dateTime, string timeZone)
        {
            if (!DateTimeGroup.IsValidTimeZone(timeZone))
            {
                throw new ArgumentOutOfRangeException(timeZone, "Not a valid timezone");
            }

            return DateTimeGroup.ConvertToDateTimeGroup(dateTime, timeZone);
        }

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
    }
}