using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Benday.EasyAuthDemo.UnitTests.Utilities
{
    [TestClass]
    public class UnitTestUtilityFixture
    {
        [TestMethod]
        public void IsDateTimeRecent_LessThan1SecondBefore_ReturnsTrue()
        {
            DateTime value1 = new DateTime(1900, 1, 1);
            DateTime value2 = value1.AddMilliseconds(-999);

            Assert.IsTrue(
                UnitTestUtility.IsDateTimeRecent(value1, value2),
                "Expected value to be recent.");
        }

        [TestMethod]
        public void IsDateTimeRecent_LessThan1SecondAfter_ReturnsTrue()
        {

            DateTime value1 = new DateTime(1900, 1, 1);
            DateTime value2 = value1.AddMilliseconds(999);

            Assert.IsTrue(
                UnitTestUtility.IsDateTimeRecent(value1, value2),
                "Expected value to be recent.");
        }

        [TestMethod]
        public void IsDateTimeRecent_Equals_ReturnsTrue()
        {
            DateTime value1 = new DateTime(1900, 1, 1);
            DateTime value2 = value1;

            Assert.IsTrue(
                UnitTestUtility.IsDateTimeRecent(value1, value2),
                "Expected value to be recent.");
        }

        [TestMethod]
        public void IsDateTimeRecent_GreaterThan1SecondBefore_ReturnsFalse()
        {
            DateTime value1 = new DateTime(1900, 1, 1);
            DateTime value2 = value1.AddMilliseconds(-1001);

            Assert.IsFalse(
                UnitTestUtility.IsDateTimeRecent(value1, value2),
                "Expected value to not be recent.");
        }

        [TestMethod]
        public void IsDateTimeRecent_GreaterThan1SecondAfter_ReturnsFalse()
        {
            DateTime value1 = new DateTime(1900, 1, 1);
            DateTime value2 = value1.AddMilliseconds(1001);

            Assert.IsFalse(
                UnitTestUtility.IsDateTimeRecent(value1, value2),
                "Expected value to not be recent.");
        }
    }
}
