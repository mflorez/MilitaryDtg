using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Usa.Mil.Dtg
{
    public struct Mil
    {
        /// <summary>
        /// Military Phonetic Alphabet properties.
        /// </summary>
        public struct Alphabet
        {            
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
        }

        /// <summary>
        /// Military time zone abbreviations
        /// </summary>
        public struct TimeZoneAbbreviation
        {
            public static string A { get { return "A"; } }
            public static string B { get { return "B"; } }
            public static string C { get { return "C"; } }
            public static string D { get { return "D"; } }
            public static string E { get { return "E"; } }
            public static string F { get { return "F"; } }
            public static string G { get { return "G"; } }
            public static string H { get { return "H"; } }
            public static string I { get { return "I"; } }
            public static string K { get { return "K"; } }
            public static string L { get { return "L"; } }
            public static string M { get { return "M"; } }
            public static string N { get { return "N"; } }
            public static string O { get { return "O"; } }
            public static string P { get { return "P"; } }
            public static string Q { get { return "Q"; } }
            public static string R { get { return "R"; } }
            public static string S { get { return "S"; } }
            public static string T { get { return "T"; } }
            public static string U { get { return "U"; } }
            public static string V { get { return "V"; } }
            public static string W { get { return "W"; } }
            public static string X { get { return "X"; } }
            public static string Y { get { return "Y"; } }
            public static string Z { get { return "Z"; } }
        }

        #region Military Time Zone Names
        /// <summary>
        /// Military time zone names
        /// </summary>
        public static IReadOnlyCollection<String> TimeZoneNames = new String[]
        {
            Alphabet.Alpha,
            Alphabet.Bravo,
            Alphabet.Charlie,
            Alphabet.Delta,
            Alphabet.Echo,
            Alphabet.Foxtrot,
            Alphabet.Golf,
            Alphabet.Hotel,
            Alphabet.India,
            Alphabet.Kilo,
            Alphabet.Lima,
            Alphabet.Mike,
            Alphabet.November,
            Alphabet.Oscar,
            Alphabet.Papa,
            Alphabet.Quebec,
            Alphabet.Romeo,
            Alphabet.Sierra,
            Alphabet.Tango,
            Alphabet.Uniform,
            Alphabet.Victor,
            Alphabet.Whiskey,
            Alphabet.Xray,
            Alphabet.Yankee,
            Alphabet.Zulu
        };
        #endregion

        #region Time Zone Letter Time Offset Relationship
        /// <summary>
        /// Time zone abbreviation to time offset values
        /// </summary>
        public enum TimeZoneOffset
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
