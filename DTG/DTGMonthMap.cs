using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DateTimeGroup
{
    internal class DTGMonthMap
    {
        private List<DTGMonthMapItem> _dtgMonthMap;

        public DTGMonthMap()
        {
            _dtgMonthMap = new List<DTGMonthMapItem>();

            _dtgMonthMap.Add(new DTGMonthMapItem(1, "JAN"));
            _dtgMonthMap.Add(new DTGMonthMapItem(2, "FEB"));
            _dtgMonthMap.Add(new DTGMonthMapItem(3, "MAR"));
            _dtgMonthMap.Add(new DTGMonthMapItem(4, "APR"));
            _dtgMonthMap.Add(new DTGMonthMapItem(5, "MAY"));
            _dtgMonthMap.Add(new DTGMonthMapItem(6, "JUN"));
            _dtgMonthMap.Add(new DTGMonthMapItem(7, "JUL"));
            _dtgMonthMap.Add(new DTGMonthMapItem(8, "AUG"));
            _dtgMonthMap.Add(new DTGMonthMapItem(9, "SEP"));
            _dtgMonthMap.Add(new DTGMonthMapItem(10, "OCT"));
            _dtgMonthMap.Add(new DTGMonthMapItem(11, "NOV"));
            _dtgMonthMap.Add(new DTGMonthMapItem(12, "DEC"));

        }

        public string StringForMonthIndex(int monthIndex)
        {
            foreach (DTGMonthMapItem item in _dtgMonthMap)
            {
                if (item.MonthIndex == monthIndex)
                {
                    return item.MonthName;
                }
            }

            throw new ArgumentOutOfRangeException("MonthIndex not valid");
        }

        public int IndexForMonthName(string monthName)
        {
            foreach (DTGMonthMapItem item in _dtgMonthMap)
            {
                if (item.MonthName == monthName)
                {
                    return item.MonthIndex;
                }
            }

            throw new ArgumentOutOfRangeException("MonthName not valid");
        }
        public bool ContainsMonthName(string monthName)
        {
            foreach (DTGMonthMapItem item in _dtgMonthMap)
            {
                if (item.MonthName == monthName)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
