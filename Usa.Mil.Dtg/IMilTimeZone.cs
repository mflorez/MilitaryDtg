using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Usa.Mil.Dtg
{
    public interface IMilTimeZone
    {
        int Offset { get; set; }
        string Abbreviation { get; set; }
        string MilTimeZoneName { get; set; }
        TimeZoneInfo TimeZoneInfo { get; set; }
    }
}
