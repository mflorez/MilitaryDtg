using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Usa.Mil.Dtg.Properties;

namespace Usa.Mil.Dtg.Tests
{
    [TestClass()]
    public class MilDateFormatProviderTests
    {
        [TestMethod()]
        public void FormatTest()
        {
            string dtgString = "07142509 Z OCT 2017";
            string format = "{0:" + Settings.Default.DefaultDateTimeGroupStringFormat + "}";
            IMilDate mdto = DateTimeMil.GetMilDateFromString(dtgString);
            if (mdto.MilDateOffset.HasValue)
            {
                string mdtoString = String.Format(new MilDateFormatProvider(), format, mdto).ToUpper();
                Assert.AreEqual(dtgString, mdtoString);
            }
        }
    }
}