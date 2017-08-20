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
        #region Properties    
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
        #endregion

        public DtgTransform(string dateTimeGroupString)
        {            
            ProcessDtgTransform(dateTimeGroupString);
        }

        #region Methods
        /// <summary>
        /// Process DTG string into values that can be used on a DateTime instance.
        /// </summary>
        /// <param name="dateTimeGroupString"></param>
        private void ProcessDtgTransform(string dateTimeGroupString)
        {
            if (String.IsNullOrEmpty(dateTimeGroupString)) throw new ArgumentNullException("dateTimeGroupString");

            this.DtgStringValue = dateTimeGroupString;
            string dtgVal = dateTimeGroupString.Replace(" ", String.Empty);
            string dayTimePart = new string(dtgVal.TakeWhile(c => !Char.IsLetter(c)).ToArray());
            SetDayHourMinuteSecond(dayTimePart);

            string timeZoneMonthPart = new string(dtgVal.Remove(0, dayTimePart.Length).TakeWhile(c => Char.IsLetter(c)).ToArray());
            string timeZonePart = timeZoneMonthPart.Substring(0, 1);
            SetTimeZonePart(timeZonePart);

            string monthPart = timeZoneMonthPart.Remove(0, timeZonePart.Length);
            SetMonthPart(monthPart);

            string yearPart = dtgVal.Remove(0, dayTimePart.Length + timeZoneMonthPart.Length);
            SetYearPart(yearPart);
        }

        /// <summary>
        /// Set the day, hour, minute, and second values to be used on DateTime.
        /// </summary>
        /// <param name="dayTimePart"></param>
        private void SetDayHourMinuteSecond(string dayTimePart)
        {
            if (String.IsNullOrEmpty(dayTimePart)) throw new ArgumentNullException("dayTimePart");

            int day = 0, hour = 0, minute = 0, second = 0;
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

            this.Day = (day > 31 || day < 0) ? 0 : day;
            this.Hour = (hour > 24 || hour < 0) ? 0 : hour;
            this.Minute = (minute > 60 || minute < 0) ? 0: minute;
            this.Second = (second > 60 || second < 0) ? 0 : second;
        }

        /// <summary>
        /// Set the year part
        /// </summary>
        /// <param name="yearPart"></param>
        private void SetYearPart(string yearPart)
        {
            if (String.IsNullOrEmpty(yearPart)) throw new ArgumentNullException("yearPart");

            int year = 0;
            if (yearPart.Length == 2)
            {
                year = Convert.ToInt32(yearPart) + 2000;
            }
            else if (yearPart.Length == 4)
            {
                year = Convert.ToInt32(yearPart);
            }
            else
            {
                year = 0;
            }
            this.Year = year;
        }

        /// <summary>
        /// Set the time zone part military abbreviation
        /// </summary>
        /// <param name="timeZonePart"></param>
        private void SetTimeZonePart(string timeZonePart)
        {
            if (String.IsNullOrEmpty(timeZonePart)) throw new ArgumentNullException("timeZonePart");

            if (timeZonePart.Length == 1 && Char.IsLetter(timeZonePart[0])) // It is one character and it is a letter.
            {
                this.MilitaryTimeZoneAbbreviation = timeZonePart;
            }
        }

        /// <summary>
        /// Set month part
        /// </summary>
        /// <param name="monthPart"></param>
        private void SetMonthPart(string monthPart)
        {
            if (String.IsNullOrEmpty(monthPart)) throw new ArgumentNullException("monthPart");

            if (monthPart.Length == 3) // Three-letter month name abbreviation.
            {
                // var pair = Military.AbbreviatedMonthNames.Select((Value, Index) => new { Value, Index }).Single(p => p.Value.Equals(monthPart, StringComparison.InvariantCultureIgnoreCase));
                var monthIdx = Military.AbbreviatedMonthNames.FindIndex(x => x.Equals(monthPart, StringComparison.InvariantCultureIgnoreCase));
                this.Month = monthIdx + 1;
            }
        }
        #endregion
    }
}
