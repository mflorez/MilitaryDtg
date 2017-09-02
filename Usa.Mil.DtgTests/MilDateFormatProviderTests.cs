using Microsoft.VisualStudio.TestTools.UnitTesting;
using Usa.Mil.Dtg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Usa.Mil.Dtg.Tests
{
    [TestClass()]
    public class MilDateFormatProviderTests
    {
        [TestMethod()]
        public void FormatTest()
        {
            string dtgString = "07142509 Z OCT 2017";
            string format = "{0:ddHHmmss dtz MMM yyyy}";
            IMilDate mdto = DateTimeMil.GetMilDateFromString(dtgString);
            if (mdto.MilDateOffset.HasValue)
            {
                string mdtoString = String.Format(new MilDateFormatProvider(), format, mdto).ToUpper();
                Assert.AreEqual(dtgString, mdtoString);
            }
        }
    }
}