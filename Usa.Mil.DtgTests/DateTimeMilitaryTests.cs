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
    public class DateTimeMilitaryTests
    {
        [TestMethod()]
        public void GetMilitaryDateTimeOffsetTest()
        {
            string milZoneAbbr = Military.TimeZoneAbbreviationToOffsetVal.C.ToString();
            string milZoneName = Military.Charlie;
            DateTime dt = new DateTime(2012, 4, 14, 7, 8, 11);
            IMilitaryDateTimeOffset milDtgOffset = DateTimeMilitary.GetMilitaryDateTimeOffset(dt, milZoneAbbr);
            Assert.AreEqual(milZoneName, milDtgOffset.MilitaryTimeZone.MilitarTimeZoneName);
            Assert.AreEqual(milZoneAbbr, milDtgOffset.MilitaryTimeZone.Abbreviation);            
        }
    }
}