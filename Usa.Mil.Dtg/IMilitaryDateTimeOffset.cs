using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Usa.Mil.Dtg
{
    public interface IMilitaryDateTimeOffset
    {
        IMilitaryTimeZone MilitaryTimeZone { get; set; }
        DateTimeOffset MilitaryDateTimeOffset { get; set; }
    }
}
