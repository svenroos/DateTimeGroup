using System;
using System.Collections.Generic;
using System.Linq;

namespace DateTimeGroupExtension
{
    internal class DateTimeGroupMonths
    {
#if NET5_0_OR_GREATER
        private readonly Dictionary<int, string> _dtgMonthMap = new();
#else
        private readonly Dictionary<int, string> _dtgMonthMap = new Dictionary<int, string>();
#endif
        internal DateTimeGroupMonths()
        {
            _dtgMonthMap.Add(1, "JAN");
            _dtgMonthMap.Add(2, "FEB");
            _dtgMonthMap.Add(3, "MAR");
            _dtgMonthMap.Add(4, "APR");
            _dtgMonthMap.Add(5, "MAY");
            _dtgMonthMap.Add(6, "JUN");
            _dtgMonthMap.Add(7, "JUL");
            _dtgMonthMap.Add(8, "AUG");
            _dtgMonthMap.Add(9, "SEP");
            _dtgMonthMap.Add(10, "OCT");
            _dtgMonthMap.Add(11, "NOV");
            _dtgMonthMap.Add(12, "DEC");

        }

        internal string StringForMonthIndex(int monthIndex)
        {
            if (_dtgMonthMap.TryGetValue(monthIndex, out string? month))
            {
                if (string.IsNullOrEmpty(month))
                {
                    throw new ArgumentOutOfRangeException(month, "Not a valid month");
                }
                else
                {
                    return month;
                }
            }
            else
            {
                throw new ArgumentOutOfRangeException(monthIndex.ToString(), "Not a valid month index");
            }
        }

        internal int IndexForMonthName(string monthName)
        {
            if (string.IsNullOrEmpty(monthName))
            {
                throw new ArgumentNullException(monthName);
            }

            if (!_dtgMonthMap.ContainsValue(monthName))
            {
                throw new ArgumentOutOfRangeException(monthName, "Not a valid month");
            }

            return _dtgMonthMap.FirstOrDefault(x => x.Value == monthName).Key;
        }
        internal bool IsValidMonthName(string monthName)
        {
            if (string.IsNullOrEmpty(monthName))
            {
                throw new ArgumentNullException(monthName);
            }

            if (_dtgMonthMap.ContainsValue(monthName))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        internal bool IsValidMonthIndec(int monthIndex)
        {
            if (_dtgMonthMap.ContainsKey(monthIndex))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
