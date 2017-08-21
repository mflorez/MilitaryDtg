using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Usa.Mil.Dtg
{
    public static class DateTimeMil
    {                       
        private static IList<IMilTimeZone> militaryTimeZones;
        public static IList<IMilTimeZone> MilitaryTimeZones
        {
            get { return militaryTimeZones; }
        }

        static DateTimeMil()
        {
            militaryTimeZones = new List<IMilTimeZone>();
            foreach (var value in Enum.GetValues(typeof(Military.TimeZoneAbbreviationToOffsetVal)))
            {
                int intVal = (int)value;
                string strVal = value.ToString();
                TimeZoneInfo tZ = Military.SystemTimeZones.Where(i => i.BaseUtcOffset.Hours.Equals(intVal)).FirstOrDefault();                
                String mTName = Military.MilitaryZoneNames.Where(z => z.StartsWith(strVal, StringComparison.InvariantCultureIgnoreCase)).FirstOrDefault();
                militaryTimeZones.Add(new MilTimeZone() { TimeZoneInfo = tZ, Abbreviation = strVal, Offset = intVal, MilTimeZoneName = mTName });
            }
        }

        public static IMilDate GetMilDate(DateTime? date, string militaryTimeZoneAbbreviation)
        {
            IMilDate mdto = new MilDate();
            if(date.HasValue)
            {
                IMilTimeZone mtz = MilitaryTimeZones.Where(i => i.Abbreviation.Equals(militaryTimeZoneAbbreviation)).FirstOrDefault();
                mdto.MilitaryTimeZone = mtz;
                mdto.MilDateOffset = new DateTimeOffset(date.Value, mtz.TimeZoneInfo.BaseUtcOffset);
            }            
            return mdto;
        }

        public static IMilDate GetMilDateFromString(string dateTimeGroupString)
        {
            IDtgTransform dT = new DtgTransform(dateTimeGroupString);
            DateTime? date = GetDateTime(dT);
            IMilDate mdto = new MilDate();
            if(date.HasValue)
            {
                IMilTimeZone mtz = MilitaryTimeZones.Where(i => i.Abbreviation.Equals(dT.MilitaryTimeZoneAbbreviation)).FirstOrDefault();
                mdto.MilitaryTimeZone = mtz;
                mdto.MilDateOffset = new DateTimeOffset(date.Value, mtz.TimeZoneInfo.BaseUtcOffset);
            }            
            return mdto;
        }

        /// <summary>
        /// Get DateTime either with the time or no time part as provided.
        /// </summary>
        /// <param name="dtgTransform"></param>
        /// <returns></returns>
        private static DateTime? GetDateTime(IDtgTransform dtgTransform)
        {
            IDtgTransform dT = dtgTransform;
            DateTime? date;
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
                date = null;                
            }
            return date;
            
        }

    }
}
