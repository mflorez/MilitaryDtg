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

        public static IMilitaryDateTimeOffset GetMilitaryDateTimeOffset(DateTime date, string militaryTimeZoneAbbreviation)
        {
            IMilitaryDateTimeOffset retMzo = new MilitaryDateTimeOffset();
            IMilitaryTimeZone mtz = DateTimeMilitary.MilitaryTimeZones.Where(i => i.Abbreviation.Equals(militaryTimeZoneAbbreviation)).FirstOrDefault();
            retMzo.MilitaryTimeZone = mtz;
            retMzo.MilitaryDateTimeOffset = new DateTimeOffset(date, mtz.TimeZoneInfo.BaseUtcOffset);
            return retMzo;
        }
    }
}
