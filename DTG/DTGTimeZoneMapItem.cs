using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DateTimeGroup
{
    internal class DTGTimeZoneMapItem
    {
        public readonly DTG.DTGTimeZone DTGTimeZone;
        public readonly string TimeZoneString;
        public readonly double Offset;

        public DTGTimeZoneMapItem(DTG.DTGTimeZone timeZone, string timeZoneString, double offset)
        {
            DTGTimeZone = timeZone;
            TimeZoneString = timeZoneString;
            Offset = offset;
        }
    }
}
