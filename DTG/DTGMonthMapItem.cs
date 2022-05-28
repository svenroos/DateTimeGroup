using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DateTimeGroup
{
    internal class DTGMonthMapItem
    {
        public readonly int MonthIndex;
        public readonly string MonthName;

        public DTGMonthMapItem(int monthIndex, string monthName)
        {
            MonthIndex = monthIndex;
            MonthName = monthName;
        }
    }
}
