using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Usa.Mil.Dtg
{
    sealed class MilDate : IMilDate
    {
        public DateTimeOffset? MilDateOffset
        {
            get;
            set;
        }

        public IMilTimeZone MilTimeZone
        {
            get;
            set;
        }       
    }
}
