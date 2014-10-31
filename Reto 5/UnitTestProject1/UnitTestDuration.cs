using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Reto5;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTestDuration
    {
        [TestMethod]
        public void TestFromDay()
        {
            Duration duration = Duration.Day;
            Assert.AreEqual(new DateTime(1976, 12, 16), duration.From(new DateTime(1976, 12, 15)));
        }

        [TestMethod]
        public void TestFromWeek()
        {
            Duration duration = Duration.Week;
            Assert.AreEqual(new DateTime(1976, 12, 16), duration.From(new DateTime(1976, 12, 9)));
        }

        [TestMethod]
        public void TestFromMonth()
        {
            Duration duration = Duration.Month;
            Assert.AreEqual(new DateTime(1976, 12, 16), duration.From(new DateTime(1976, 11, 16)));
        }

        [TestMethod, ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestFromInvalidDuration()
        {
            Duration duration = (Duration)3;
            var newDate = duration.From(new DateTime(1976, 12, 16));
        }
    }
}
