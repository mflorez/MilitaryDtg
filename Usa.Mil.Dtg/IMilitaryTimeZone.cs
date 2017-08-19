using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Usa.Mil.Dtg
{
    public interface IMilitaryTimeZone
    {
        int Offset { get; set; }
        string Abbreviation { get; set; }
        string MilitarTimeZoneName { get; set; }
        TimeZoneInfo TimeZoneInfo { get; set; }
    }
}
