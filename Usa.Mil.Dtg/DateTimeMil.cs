using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Usa.Mil.Dtg
{
    public static class DateTimeMil
    {                       
        private static IList<IMilTimeZone> milTimeZones;
        public static IList<IMilTimeZone> MilTimeZones
        {
            get { return milTimeZones; }
        }

        static DateTimeMil()
        {
            milTimeZones = new List<IMilTimeZone>();
            foreach (var value in Enum.GetValues(typeof(Mil.TimeZoneOffset)))
            {
                int intVal = (int)value;
                string strVal = value.ToString();
                TimeZoneInfo tZ = Mil.SystemTimeZones.Where(i => i.BaseUtcOffset.Hours.Equals(intVal)).FirstOrDefault();                
                String mTName = Mil.TimeZoneNames.Where(z => z.StartsWith(strVal, StringComparison.InvariantCultureIgnoreCase)).FirstOrDefault();
                milTimeZones.Add(new MilTimeZone() { TimeZoneInfo = tZ, Abbreviation = strVal, Offset = intVal, MilTimeZoneName = mTName });
            }
        }

        public static IMilDate GetMilDate(DateTime? date, string milTimeZoneAbbreviation)
        {
            IMilDate mdto = new MilDate();
            if(date.HasValue)
            {
                IMilTimeZone mtz = MilTimeZones.Where(i => i.Abbreviation.Equals(milTimeZoneAbbreviation)).FirstOrDefault();
                mdto.MilTimeZone = mtz;
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
                IMilTimeZone mtz = MilTimeZones.Where(i => i.Abbreviation.Equals(dT.MilTimeZoneAbbreviation)).FirstOrDefault();
                mdto.MilTimeZone = mtz;
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
            bool isValid = (dT.Year != 0 && dT.Month != 0 && dT.Day != 0); 
            if(isValid)
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
