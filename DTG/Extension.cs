namespace DateTimeGroup
{
    public static class DateTimeExtension
    {
        public static string ToDTGString(this DateTime dt)
        {
            DateTime dtUTC = dt.ToUniversalTime();
            return DTG.AsDTG(dtUTC);
        }
    }
}