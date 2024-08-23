using System;
using System.Collections.Generic;
using System.Linq;

namespace DateTimeGroupExtension
{
    internal class DateTimeGroupTimeZones
    {
#if NET5_0_OR_GREATER
        private readonly Dictionary<string, double> _dtgTimeZoneMap = [];
#else
        private readonly Dictionary<string, double> _dtgTimeZoneMap = new Dictionary<string, double>();
#endif
        internal DateTimeGroupTimeZones()
        {
            _dtgTimeZoneMap.Add("Y", -12.0);
            _dtgTimeZoneMap.Add("X", -11.0);
            _dtgTimeZoneMap.Add("W", -10.0);
            _dtgTimeZoneMap.Add("V*", -9.5);
            _dtgTimeZoneMap.Add("V", -9.0);
            _dtgTimeZoneMap.Add("U", -8.0);
            _dtgTimeZoneMap.Add("T", -7.0);
            _dtgTimeZoneMap.Add("S", -6.0);
            _dtgTimeZoneMap.Add("R", -5.0);
            _dtgTimeZoneMap.Add("Q*", -4.5);
            _dtgTimeZoneMap.Add("Q", -4.0);
            _dtgTimeZoneMap.Add("P*", -3.5);
            _dtgTimeZoneMap.Add("P", -3.0);
            _dtgTimeZoneMap.Add("O", -2.0);
            _dtgTimeZoneMap.Add("N", -1.0);

            _dtgTimeZoneMap.Add("Z", 0.0);

            _dtgTimeZoneMap.Add("A", 1.0);
            _dtgTimeZoneMap.Add("B", 2.0);
            _dtgTimeZoneMap.Add("C", 3.0);
            _dtgTimeZoneMap.Add("C*", 3.5);
            _dtgTimeZoneMap.Add("D", 4.0);
            _dtgTimeZoneMap.Add("D*", 4.5);
            _dtgTimeZoneMap.Add("E", 5.0);
            _dtgTimeZoneMap.Add("E*", 5.5);
            _dtgTimeZoneMap.Add("E#", 5.75);
            _dtgTimeZoneMap.Add("F", 6.0);
            _dtgTimeZoneMap.Add("F*", 6.5);
            _dtgTimeZoneMap.Add("G", 7.0);
            _dtgTimeZoneMap.Add("H", 8.0);
            _dtgTimeZoneMap.Add("H*", 8.0);
            _dtgTimeZoneMap.Add("I*", 9.5);
            _dtgTimeZoneMap.Add("K", 10.0);
            _dtgTimeZoneMap.Add("K*", 10.5);
            _dtgTimeZoneMap.Add("L", 11.0);
            _dtgTimeZoneMap.Add("L*", 11.0);
            _dtgTimeZoneMap.Add("M", 12.0);
            _dtgTimeZoneMap.Add("M+", 12.75);
            _dtgTimeZoneMap.Add("M*", 13.0);
            _dtgTimeZoneMap.Add("M#", 14.0);

            _dtgTimeZoneMap.Add("J", 0.0);

        }

        internal double OffsetForString(string timeZoneString)
        {
            if (string.IsNullOrEmpty(timeZoneString))
            {
                throw new ArgumentNullException(timeZoneString);
            }

            if (_dtgTimeZoneMap.TryGetValue(timeZoneString, out double offset))
            {
                return offset;
            }
            else
            {
                throw new ArgumentOutOfRangeException(timeZoneString, "Not a valid timezone");
            }
        }

        internal string StringForOffset(double timeZoneOffset)
        {
            if (!_dtgTimeZoneMap.ContainsValue(timeZoneOffset))
            {
                throw new ArgumentOutOfRangeException(timeZoneOffset.ToString(), "Not a valid timezoneoffset");
            }

            return _dtgTimeZoneMap.FirstOrDefault(x => x.Value == timeZoneOffset).Key;
        }

        internal bool ExistsTimeZone(string timeZoneString)
        {
            if (string.IsNullOrEmpty(timeZoneString))
            {
                throw new ArgumentNullException(timeZoneString);
            }

            if (_dtgTimeZoneMap.ContainsKey(timeZoneString))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        internal bool ExistsTimeZone(double timeZoneOffset)
        {
            if (_dtgTimeZoneMap.ContainsValue(timeZoneOffset))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        internal List<string> GetTimeZones()
        {
    #if NET8_0_OR_GREATER
            return [.. _dtgTimeZoneMap.Keys];
    #else
            return _dtgTimeZoneMap.Keys.ToList();
    #endif
        }

        internal List<KeyValuePair<string, double>> GetTimeZonesWithOffset()
        {
    #if NET8_0_OR_GREATER
            return [.. _dtgTimeZoneMap];
    #else
            return _dtgTimeZoneMap.ToList();
    #endif
        }
    }
}
