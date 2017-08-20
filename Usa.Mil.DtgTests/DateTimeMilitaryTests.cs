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
            IMilitaryDate milDtgOffset = DateTimeMilitary.GetMilDate(dt, milZoneAbbr);
            Assert.AreEqual(Military.Charlie, milDtgOffset.MilitaryTimeZone.MilitarTimeZoneName);
            Assert.AreEqual(milZoneAbbr, milDtgOffset.MilitaryTimeZone.Abbreviation);
        }

        [TestMethod()]
        public void GetMilDateFromStringTest()
        {
            string dtgString = "07142509 Z OCT 2017";
            IMilitaryDate milDtgOffset = DateTimeMilitary.GetMilDateFromString(dtgString);
            Assert.AreEqual(7, milDtgOffset.MilitaryDateTimeOffset.Day);
            Assert.AreEqual(14, milDtgOffset.MilitaryDateTimeOffset.Hour);
            Assert.AreEqual(25, milDtgOffset.MilitaryDateTimeOffset.Minute);
            Assert.AreEqual(9, milDtgOffset.MilitaryDateTimeOffset.Second);
            Assert.AreEqual(Military.Zulu, milDtgOffset.MilitaryTimeZone.MilitarTimeZoneName);
            Assert.AreEqual(10, milDtgOffset.MilitaryDateTimeOffset.Month);
            Assert.AreEqual(2017, milDtgOffset.MilitaryDateTimeOffset.Year);

            dtgString = "07ZOCT17";
            milDtgOffset = DateTimeMilitary.GetMilDateFromString(dtgString);
            Assert.AreEqual(7, milDtgOffset.MilitaryDateTimeOffset.Day);
            Assert.AreEqual(Military.Zulu, milDtgOffset.MilitaryTimeZone.MilitarTimeZoneName);
            Assert.AreEqual(10, milDtgOffset.MilitaryDateTimeOffset.Month);
            Assert.AreEqual(2017, milDtgOffset.MilitaryDateTimeOffset.Year);

            //string milZoneAbbreviation = "C";
            //DateTime dt = new DateTime(2012, 4, 14, 7, 8, 11);
            //IMilitaryDateTimeOffset milDateTimeOffset = DateTimeMilitary.GetMilitaryDateTimeOffset(dt, milZoneAbbreviation);
            //Console.WriteLine(milDateTimeOffset.MilitaryTimeZone.MilitarTimeZoneName);

            //Console.WriteLine(milDateTimeOffset.MilitaryDateTimeOffset.ToString("ddHHMMss " + milDateTimeOffset.MilitaryTimeZone.Abbreviation + " MMM yyyy").ToUpper());
            //Console.ReadLine();

            // ddhhmmss Z MMM YYYY

            Console.WriteLine((milDtgOffset.MilitaryDateTimeOffset.ToString("ddHHMMss " + milDtgOffset.MilitaryTimeZone.Abbreviation + " MMM yyyy").ToUpper()));
        }

        [TestMethod()]        
        public void GetMilDateFromString_NotValidDtgStringTest()
        {
            string dtgString = dtgString = "7ZOCT17"; // Time format is not correct 7 should be 07.  Only a valid DTG format is supported.
            IMilitaryDate milDtgOffset = milDtgOffset = DateTimeMilitary.GetMilDateFromString(dtgString);
            Assert.AreEqual(1, milDtgOffset.MilitaryDateTimeOffset.Day); //Day one when not valid
            Assert.AreEqual(null, milDtgOffset.MilitaryTimeZone); // No time zone was provided.
            Assert.AreEqual(1, milDtgOffset.MilitaryDateTimeOffset.Month); //Month one when not valid
            Assert.AreEqual(1, milDtgOffset.MilitaryDateTimeOffset.Year); //Year 1 when not valid.
        }
    }
}