using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DateTimeGroup
{
    internal class DTGTimeZoneMap
    {
        private List<DTGTimeZoneMapItem> _dtgTimeZoneMap;

        public DTGTimeZoneMap()
        {
            _dtgTimeZoneMap= new List<DTGTimeZoneMapItem>();

            _dtgTimeZoneMap.Add(new DTGTimeZoneMapItem(DTG.DTGTimeZone.Y, "Y", -12.0));
            _dtgTimeZoneMap.Add(new DTGTimeZoneMapItem(DTG.DTGTimeZone.X, "X", -11.0));
            _dtgTimeZoneMap.Add(new DTGTimeZoneMapItem(DTG.DTGTimeZone.W, "W", -10.0));
            _dtgTimeZoneMap.Add(new DTGTimeZoneMapItem(DTG.DTGTimeZone.VSTAR, "V*", -9.5));
            _dtgTimeZoneMap.Add(new DTGTimeZoneMapItem(DTG.DTGTimeZone.V, "V", -9.0));
            _dtgTimeZoneMap.Add(new DTGTimeZoneMapItem(DTG.DTGTimeZone.U, "U", -8.0));
            _dtgTimeZoneMap.Add(new DTGTimeZoneMapItem(DTG.DTGTimeZone.T, "T", -7.0));
            _dtgTimeZoneMap.Add(new DTGTimeZoneMapItem(DTG.DTGTimeZone.S, "S", -6.0));
            _dtgTimeZoneMap.Add(new DTGTimeZoneMapItem(DTG.DTGTimeZone.R, "R", -5.0));
            _dtgTimeZoneMap.Add(new DTGTimeZoneMapItem(DTG.DTGTimeZone.Q, "Q", -4.0));
            _dtgTimeZoneMap.Add(new DTGTimeZoneMapItem(DTG.DTGTimeZone.PSTAR, "P*", -3.5));
            _dtgTimeZoneMap.Add(new DTGTimeZoneMapItem(DTG.DTGTimeZone.P, "P", -3.0));
            _dtgTimeZoneMap.Add(new DTGTimeZoneMapItem(DTG.DTGTimeZone.O, "O", -2.0));
            _dtgTimeZoneMap.Add(new DTGTimeZoneMapItem(DTG.DTGTimeZone.N, "N", -1.0));

            _dtgTimeZoneMap.Add(new DTGTimeZoneMapItem(DTG.DTGTimeZone.Z, "Z", 0.0));

            _dtgTimeZoneMap.Add(new DTGTimeZoneMapItem(DTG.DTGTimeZone.A, "A", 1.0));
            _dtgTimeZoneMap.Add(new DTGTimeZoneMapItem(DTG.DTGTimeZone.B, "B", 2.0));
            _dtgTimeZoneMap.Add(new DTGTimeZoneMapItem(DTG.DTGTimeZone.C, "C", 3.0));
            _dtgTimeZoneMap.Add(new DTGTimeZoneMapItem(DTG.DTGTimeZone.D, "D", 4.0));
            _dtgTimeZoneMap.Add(new DTGTimeZoneMapItem(DTG.DTGTimeZone.DSTAR, "D*", 4.5));
            _dtgTimeZoneMap.Add(new DTGTimeZoneMapItem(DTG.DTGTimeZone.E, "E", 5.0));
            _dtgTimeZoneMap.Add(new DTGTimeZoneMapItem(DTG.DTGTimeZone.ESTAR, "E*", 5.5));
            _dtgTimeZoneMap.Add(new DTGTimeZoneMapItem(DTG.DTGTimeZone.F, "F", 6.0));
            _dtgTimeZoneMap.Add(new DTGTimeZoneMapItem(DTG.DTGTimeZone.FSTAR, "F*", 6.5));
            _dtgTimeZoneMap.Add(new DTGTimeZoneMapItem(DTG.DTGTimeZone.G, "G", 7.0));
            _dtgTimeZoneMap.Add(new DTGTimeZoneMapItem(DTG.DTGTimeZone.H, "H", 8.0));
            _dtgTimeZoneMap.Add(new DTGTimeZoneMapItem(DTG.DTGTimeZone.I, "I", 9.0));
            _dtgTimeZoneMap.Add(new DTGTimeZoneMapItem(DTG.DTGTimeZone.ISTAR, "I*", 9.5));
            _dtgTimeZoneMap.Add(new DTGTimeZoneMapItem(DTG.DTGTimeZone.K, "K", 10.0));
            _dtgTimeZoneMap.Add(new DTGTimeZoneMapItem(DTG.DTGTimeZone.KSTAR, "K*", 10.5));
            _dtgTimeZoneMap.Add(new DTGTimeZoneMapItem(DTG.DTGTimeZone.L, "L", 11.0));
            _dtgTimeZoneMap.Add(new DTGTimeZoneMapItem(DTG.DTGTimeZone.M, "M", 12.0));
            _dtgTimeZoneMap.Add(new DTGTimeZoneMapItem(DTG.DTGTimeZone.MSTAR, "M*", 13.0));

            _dtgTimeZoneMap.Add(new DTGTimeZoneMapItem(DTG.DTGTimeZone.J, "J", 0.0));

        }

        public string StringForTimeZone(DTG.DTGTimeZone dtgTimeZone)
        {
            foreach (DTGTimeZoneMapItem item in _dtgTimeZoneMap)
            {
                if (item.DTGTimeZone == dtgTimeZone)
                {
                    return item.TimeZoneString;
                }
            }

            throw new ArgumentOutOfRangeException("DTGTimeZone not valid");
        }

        public DTG.DTGTimeZone TimeZoneForString(string timeZoneString)
        {
            foreach (DTGTimeZoneMapItem item in _dtgTimeZoneMap)
            {
                if (item.TimeZoneString == timeZoneString)
                {
                    return item.DTGTimeZone;
                }
            }

            throw new ArgumentOutOfRangeException("TimeZoneString not valid");
        }

        public double OffsetForTimeZone(DTG.DTGTimeZone dtgTimeZone)
        {
            foreach (DTGTimeZoneMapItem item in _dtgTimeZoneMap)
            {
                if (item.DTGTimeZone == dtgTimeZone)
                {
                    return item.Offset;
                }
            }

            throw new ArgumentOutOfRangeException("DTGTimeZone not valid");
        }

        public double OffsetForString(string timeZoneString)
        {
            foreach (DTGTimeZoneMapItem item in _dtgTimeZoneMap)
            {
                if (item.TimeZoneString == timeZoneString)
                {
                    return item.Offset;
                }
            }

            throw new ArgumentOutOfRangeException("TimeZoneString not valid");
        }

        public bool ContainsString(string timeZoneString)
        {
            foreach (DTGTimeZoneMapItem item in _dtgTimeZoneMap)
            {
                if (item.TimeZoneString == timeZoneString)
                {
                    return true;
                }
            }

            return false;
        }

    }
}
