using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Usa.Mil.Dtg
{
    sealed class MilitaryDateTimeOffset : IMilitaryDateTimeOffset
    {
        public IMilitaryTimeZone MilitaryTimeZone
        {
            get;
            set;
        }

        DateTimeOffset IMilitaryDateTimeOffset.MilitaryDateTimeOffset
        {
            get;
            set;
        }
    }
}
