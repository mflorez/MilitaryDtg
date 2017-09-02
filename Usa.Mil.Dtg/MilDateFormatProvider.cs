using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Usa.Mil.Dtg
{
    /// <summary>
    /// Custom IMilDate formatter.  Use "dtz" to insert military time zone abbreviation.  
    /// MilDateFormatProvider uses same string formats as System.DateTimeOffset.
    /// </summary>
    public class MilDateFormatProvider : IFormatProvider, ICustomFormatter
    {
        public object GetFormat(Type formatType)
        {
            return (formatType == typeof(ICustomFormatter)) ? this : null;
        }

        /// <summary>
        /// Adds the "dtz" string value to allow for Military Date Time Group (DTG) string formats.
        /// </summary>
        /// <param name="format"></param>
        /// <param name="arg"></param>
        /// <param name="formatProvider"></param>
        /// <returns></returns>
        public string Format(string format, object arg, IFormatProvider formatProvider)
        {
            string mildateString = string.Empty;
            string thisFmt = String.Empty;

            if (!String.IsNullOrEmpty(format))
                thisFmt = format;

            if (arg is IMilDate)
            {
                string dtgTimeZone = "dtz";
                string replaceString = "***";
                IMilDate milDate = arg as IMilDate;
                DateTimeOffset? dto = milDate.MilDateOffset;
                mildateString = dto.Value.ToString(thisFmt.Replace(dtgTimeZone, replaceString)).Replace(replaceString, milDate.MilTimeZone.Abbreviation);
            }
            else
            {
                try
                {
                    return HandleOtherFormats(format, arg);
                }
                catch (FormatException e)
                {
                    throw new FormatException(String.Format("The format of '{0}' is invalid.", format), e);
                }
            }

            return mildateString;                
        }

        private string HandleOtherFormats(string format, object arg)
        {
            if (arg is IFormattable)
                return ((IFormattable)arg).ToString(format, CultureInfo.CurrentCulture);
            else if (arg != null)
                return arg.ToString();
            else
                return String.Empty;
        }

    }
}
