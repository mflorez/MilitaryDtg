using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Usa.Mil.Dtg
{
    public static class DateTimeMilitary
    {                       
        private static IList<IMilitaryTimeZone> militaryTimeZones;
        public static IList<IMilitaryTimeZone> MilitaryTimeZones
        {
            get { return militaryTimeZones; }
        }

        static DateTimeMilitary()
        {
            militaryTimeZones = new List<IMilitaryTimeZone>();
            foreach (var value in Enum.GetValues(typeof(Military.TimeZoneAbbreviationToOffsetVal)))
            {
                int intVal = (int)value;
                string strVal = value.ToString();
                TimeZoneInfo tZ = Military.SystemTimeZones.Where(i => i.BaseUtcOffset.Hours.Equals(intVal)).FirstOrDefault();                
                String mTName = Military.MilitaryZoneNames.Where(z => z.StartsWith(strVal, StringComparison.InvariantCultureIgnoreCase)).FirstOrDefault();
                militaryTimeZones.Add(new MilitaryTimeZone() { TimeZoneInfo = tZ, Abbreviation = strVal, Offset = intVal, MilitarTimeZoneName = mTName });
            }
        }

        public static IMilitaryDate GetMilDate(DateTime date, string militaryTimeZoneAbbreviation)
        {
            IMilitaryDate mdto = new MilitaryDate();
            if(date.Year != 1)
            {
                IMilitaryTimeZone mtz = MilitaryTimeZones.Where(i => i.Abbreviation.Equals(militaryTimeZoneAbbreviation)).FirstOrDefault();
                mdto.MilitaryTimeZone = mtz;
                mdto.MilitaryDateTimeOffset = new DateTimeOffset(date, mtz.TimeZoneInfo.BaseUtcOffset);
            }            
            return mdto;
        }

        public static IMilitaryDate GetMilDateFromString(string dateTimeGroupString)
        {
            IDtgTransform dT = new DtgTransform(dateTimeGroupString);
            DateTime date = GetDateTime(dT);
            IMilitaryDate mdto = new MilitaryDate();
            if(date.Year != 1)
            {
                IMilitaryTimeZone mtz = MilitaryTimeZones.Where(i => i.Abbreviation.Equals(dT.MilitaryTimeZoneAbbreviation)).FirstOrDefault();
                mdto.MilitaryTimeZone = mtz;
                mdto.MilitaryDateTimeOffset = new DateTimeOffset(date, mtz.TimeZoneInfo.BaseUtcOffset);
            }            
            return mdto;
        }

        /// <summary>
        /// Get DateTime either with the time or no time part as provided.
        /// </summary>
        /// <param name="dtgTransform"></param>
        /// <returns></returns>
        private static DateTime GetDateTime(IDtgTransform dtgTransform)
        {
            IDtgTransform dT = dtgTransform;
            DateTime date;
            if(dT.Year != 0 && dT.Month != 0 && dT.Day != 0 && dT.Hour == 0 && dT.Minute == 0 && dT.Second == 0)
            {
                date = new DateTime(dT.Year, dT.Month, dT.Day);                
            }
            else if(dT.Year != 0 && dT.Month != 0 && dT.Day != 0 && dT.Hour != 0 && dT.Minute != 0 && dT.Second != 0)
            {
                date = new DateTime(dT.Year, dT.Month, dT.Day, dT.Hour, dT.Minute, dT.Second);                
            }
            else
            {
                date = new DateTime();                
            }
            return date;
            
        }

    }
}
