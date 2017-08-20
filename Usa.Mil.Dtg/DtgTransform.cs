using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Usa.Mil.Dtg
{
    public class DtgTransform : IDtgTransform
    {
        public int Day
        {
            get;
            set;
        }

        public string DtgStringValue
        {
            get;
            set;
        }

        public int Hour
        {
            get;
            set;
        }

        public int Minute
        {
            get;
            set;
        }

        public int Month
        {
            get;
            set;
        }

        public int Second
        {
            get;
            set;
        }

        public int Year
        {
            get;
            set;
        }

        public string MilitaryTimeZoneAbbreviation
        {
            get;
            set;
        }

        public DtgTransform(string dateTimeGroupString)
        {
            this.DtgStringValue = dateTimeGroupString;
            IList<string> abbreviatedMonthNames = DateTimeFormatInfo.CurrentInfo.AbbreviatedMonthNames; 
                  
            string dtgVal = dateTimeGroupString.Replace(" ", String.Empty);
            string dayTimePart = new string(dtgVal.TakeWhile(c => !Char.IsLetter(c)).ToArray());
            int day = 0, hour = 0, minute = 0, second = 0;
            /*
             If odd, time day is not formed correctly.
             */
            if (dayTimePart.Length % 2 == 0)
            {
                IEnumerable<string> parts = dayTimePart.SplitInParts(2);
                /*
                 There are day and time values
                 */
                if (parts.Count() == 1)
                {
                    day = Convert.ToInt32(parts.First());
                }
                else if (parts.Count() == 2)
                {
                    day = Convert.ToInt32(parts.First());
                    hour = Convert.ToInt32(parts.Last());
                }
                else if (parts.Count() == 3)
                {
                    day = Convert.ToInt32(parts.First());
                    hour = Convert.ToInt32(parts.ElementAt(1));
                    minute = Convert.ToInt32(parts.Last());
                }
                else if (parts.Count() == 4)
                {
                    day = Convert.ToInt32(parts.First());
                    hour = Convert.ToInt32(parts.ElementAt(1));
                    minute = Convert.ToInt32(parts.ElementAt(2));
                    second = Convert.ToInt32(parts.Last());
                }
            }

            string timeZoneMonthPart = new string(dtgVal.Remove(0, dayTimePart.Length).TakeWhile(c => Char.IsLetter(c)).ToArray());
            string timeZonePart = timeZoneMonthPart.Substring(0, 1);
            this.MilitaryTimeZoneAbbreviation = timeZonePart;
            string monthPart = timeZoneMonthPart.Remove(0, timeZonePart.Length);            
            var pair = abbreviatedMonthNames.Select((Value, Index) => new { Value, Index }).Single(p => p.Value.Equals(monthPart, StringComparison.InvariantCultureIgnoreCase));
            this.Day = day;
            this.Hour = hour;
            this.Minute = minute;
            this.Second = second;
            this.Month = pair.Index + 1;
            
            string yearPart = dtgVal.Remove(0, dayTimePart.Length + timeZoneMonthPart.Length);

            if(yearPart.Length == 2)
            {
                this.Year = Convert.ToInt32(yearPart) + 2000;
            }
            else
            {
                this.Year = Convert.ToInt32(yearPart);
            }            

        }
    }
}
