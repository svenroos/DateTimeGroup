namespace DateTimeGroup
{
    public static class DateTimeExtension
    {
        public static string ToDTGString(this DateTime dateTime)
        {
            return DTG.ConvertToDTG(dateTime);
        }

        public static string ToDTGString(this DateTime dateTime, string timeZone)
        {
            if (!DTG.IsValidTimeZone(timeZone))
            {
                throw new ArgumentOutOfRangeException(nameof(timeZone));
            }

            return DTG.ConvertToDTG(dateTime, timeZone);
        }

        public static string ToDTGString(this DateTime dateTime, DTG.DTGTimeZone dtgTimeZone)
        {
            return DTG.ConvertToDTG(dateTime, dtgTimeZone);
        }

        public static DateTime FromDTGString(string dtgString)
        {
            if (string.IsNullOrEmpty(dtgString))
            {
                throw new ArgumentNullException(dtgString);
            }

             return DTG.ConvertFromDTGString(dtgString);
        }
    }
}