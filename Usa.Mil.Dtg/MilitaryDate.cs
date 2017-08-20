using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Usa.Mil.Dtg
{
    sealed class MilitaryDate : IMilitaryDate
    {
        public IMilitaryTimeZone MilitaryTimeZone
        {
            get;
            set;
        }

        DateTimeOffset IMilitaryDate.MilitaryDateTimeOffset
        {
            get;
            set;
        }
    }
}
