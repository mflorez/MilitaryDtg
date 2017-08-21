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
        public void GetMilDateTest()
        {
            string milZoneAbbr = Military.TimeZoneAbbreviationToOffsetVal.C.ToString();
            DateTime dt = new DateTime(2012, 4, 14, 7, 8, 11);
            IMilDate milDtgOffset = DateTimeMil.GetMilDate(dt, milZoneAbbr);
            Assert.AreEqual(Military.Charlie, milDtgOffset.MilitaryTimeZone.MilTimeZoneName);
            Assert.AreEqual(milZoneAbbr, milDtgOffset.MilitaryTimeZone.Abbreviation);
        }

        [TestMethod()]
        public void GetMilDateFromStringTest()
        {
            string dtgString = "07142509 Z OCT 2017";
            IMilDate mdto = DateTimeMil.GetMilDateFromString(dtgString);
            Assert.AreEqual(7, mdto.MilDateOffset.Value.Day);
            Assert.AreEqual(14, mdto.MilDateOffset.Value.Hour);
            Assert.AreEqual(25, mdto.MilDateOffset.Value.Minute);
            Assert.AreEqual(9, mdto.MilDateOffset.Value.Second);
            Assert.AreEqual(Military.Zulu, mdto.MilitaryTimeZone.MilTimeZoneName);
            Assert.AreEqual(10, mdto.MilDateOffset.Value.Month);
            Assert.AreEqual(2017, mdto.MilDateOffset.Value.Year);

            dtgString = "07ZOCT17";
            mdto = DateTimeMil.GetMilDateFromString(dtgString);
            Assert.AreEqual(7, mdto.MilDateOffset.Value.Day);
            Assert.AreEqual(Military.Zulu, mdto.MilitaryTimeZone.MilTimeZoneName);
            Assert.AreEqual(10, mdto.MilDateOffset.Value.Month);
            Assert.AreEqual(2017, mdto.MilDateOffset.Value.Year);            
        }

        [TestMethod()]        
        public void GetMilDateFromString_NotValidDtgStringTest()
        {
            string dtgString = dtgString = "7ZOCT17"; // Time format is not correct 7 should be 07.  Only a valid DTG format is supported.
            IMilDate milDtgOffset = milDtgOffset = DateTimeMil.GetMilDateFromString(dtgString);
            Assert.AreEqual(null, milDtgOffset.MilDateOffset); 
            Assert.AreEqual(null, milDtgOffset.MilitaryTimeZone);             
        }
    }
}