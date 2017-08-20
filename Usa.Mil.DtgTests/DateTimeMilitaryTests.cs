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
        public void GetMilDateTimeOffsetTest()
        {
            string milZoneAbbr = Military.TimeZoneAbbreviationToOffsetVal.C.ToString();            
            DateTime dt = new DateTime(2012, 4, 14, 7, 8, 11);
            IMilitaryDateTimeOffset milDtgOffset = DateTimeMilitary.GetMilDateTimeOffset(dt, milZoneAbbr);
            Assert.AreEqual(Military.Charlie, milDtgOffset.MilitaryTimeZone.MilitarTimeZoneName);
            Assert.AreEqual(milZoneAbbr, milDtgOffset.MilitaryTimeZone.Abbreviation);
        }

        [TestMethod()]
        public void GetMilDateTimeOffsetFromStringTest()
        {
            string dtgString = "07142509 Z OCT 2017";
            IMilitaryDateTimeOffset milDtgOffset = DateTimeMilitary.GetMilDateTimeOffsetFromString(dtgString);
            Assert.AreEqual(7, milDtgOffset.MilitaryDateTimeOffset.Day);
            Assert.AreEqual(14, milDtgOffset.MilitaryDateTimeOffset.Hour);
            Assert.AreEqual(25, milDtgOffset.MilitaryDateTimeOffset.Minute);
            Assert.AreEqual(9, milDtgOffset.MilitaryDateTimeOffset.Second);
            Assert.AreEqual(Military.Zulu, milDtgOffset.MilitaryTimeZone.MilitarTimeZoneName);
            Assert.AreEqual(10, milDtgOffset.MilitaryDateTimeOffset.Month);
            Assert.AreEqual(2017, milDtgOffset.MilitaryDateTimeOffset.Year);
        }
    }
}