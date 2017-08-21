using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Usa.Mil.Dtg
{
    public static class Mil
    {
        #region Military Phonetic Alphabet properties.
        public static string Alpha { get { return "Alpha"; } }
        public static string Bravo { get { return "Bravo"; } }
        public static string Charlie { get { return "Charlie"; } }
        public static string Delta { get { return "Delta"; } }
        public static string Echo { get { return "Echo"; } }
        public static string Foxtrot { get { return "Foxtrot"; } }
        public static string Golf { get { return "Golf"; } }
        public static string Hotel { get { return "Hotel"; } }
        public static string India { get { return "India"; } }
        public static string Kilo { get { return "Kilo"; } }
        public static string Lima { get { return "Lima"; } }
        public static string Mike { get { return "Mike"; } }
        public static string November { get { return "November"; } }
        public static string Oscar { get { return "Oscar"; } }
        public static string Papa { get { return "Papa"; } }
        public static string Quebec { get { return "Quebec"; } }
        public static string Romeo { get { return "Romeo"; } }
        public static string Sierra { get { return "Sierra"; } }
        public static string Tango { get { return "Tango"; } }
        public static string Uniform { get { return "Uniform"; } }
        public static string Victor { get { return "Victor"; } }
        public static string Whiskey { get { return "Whiskey"; } }
        public static string Xray { get { return "X-ray"; } }
        public static string Yankee { get { return "Yankee"; } }
        public static string Zulu { get { return "Zulu"; } }
        #endregion
        
        #region Military Time Zone Names
        /// <summary>
        /// Military time zone names
        /// </summary>
        public static IReadOnlyCollection<String> MilZoneNames = new String[]
        {
            Mil.Alpha,
            Mil.Bravo,
            Mil.Charlie,
            Mil.Delta,
            Mil.Echo,
            Mil.Foxtrot,
            Mil.Golf,
            Mil.Hotel,
            Mil.India,
            Mil.Kilo,
            Mil.Lima,
            Mil.Mike,
            Mil.November,
            Mil.Oscar,
            Mil.Papa,
            Mil.Quebec,
            Mil.Romeo,
            Mil.Sierra,
            Mil.Tango,
            Mil.Uniform,
            Mil.Victor,
            Mil.Whiskey,
            Mil.Xray,
            Mil.Yankee,
            Mil.Zulu
        };
        #endregion

        #region Time Zone Letter Time Offset Relationship
        /// <summary>
        /// Time zone abbreviation to time offset values
        /// </summary>
        public enum TimeZoneAbbreviationToOffsetVal
        {
            A = 1,
            B = 2,
            C = 3,
            D = 4,
            E = 5,
            F = 6,
            G = 7,
            H = 8,
            I = 9,
            K = 10,
            L = 11,
            M = 12,
            N = -1,
            O = -2,
            P = -3,
            Q = -4,
            R = -5,
            S = -6,
            T = -7,
            U = -8,
            V = -9,
            W = -10,
            X = -11,
            Y = -12,
            Z = 0
        }

        #endregion
       
        /// <summary>
        /// Global time zones
        /// </summary>
        public static IReadOnlyCollection<TimeZoneInfo> SystemTimeZones = TimeZoneInfo.GetSystemTimeZones();

        /// <summary>
        /// Abbreviated month names
        /// </summary>
        public static List<string> AbbreviatedMonthNames = DateTimeFormatInfo.CurrentInfo.AbbreviatedMonthNames.ToList<string>();
    }
}
