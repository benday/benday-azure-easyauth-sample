using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Benday.EasyAuthDemo.Api.ServiceLayers;

namespace Benday.EasyAuthDemo.UnitTests.ServiceLayer
{
    [TestClass]
    public class DefaultSearchStringParserStrategyFixture
    {
        private DefaultSearchStringParserStrategy _SystemUnderTest;
        public DefaultSearchStringParserStrategy SystemUnderTest
        {
            get
            {
                if (_SystemUnderTest == null)
                {
                    _SystemUnderTest = new DefaultSearchStringParserStrategy();
                }

                return _SystemUnderTest;
            }
        }

        private void AssertItem(string[] actualValues, int index, string expected)
        {
            Assert.IsNotNull(actualValues);
            Assert.AreNotEqual<int>(0, actualValues.Length, "Should not be zero length.");
            Assert.IsTrue(index < actualValues.Length, "No item at index '{0}'.  Index will be out of bounds.", index);
            Assert.AreEqual<string>(expected, actualValues[index], "Value at index '{0}' is wrong.", index);
        }

        private static readonly string SemiColonDelimiter = ";";
        private static readonly string SemiColonDelimiterPlusSpace = "; ";
        
        private static readonly string CommaDelimiter = ",";
        private static readonly string CommaDelimiterPlusSpace = ", ";

        [TestMethod]
        public void ParseNoValueSearchStringWithoutDelimiter()
        {
            string[] result = SystemUnderTest.Parse(String.Empty);

            Assert.AreEqual<int>(0, result.Length, "Result count was wrong.");
        }

        [TestMethod]
        public void ParseNoValueSearchStringWithSemiColonDelimiter()
        {
            string[] result = SystemUnderTest.Parse(SemiColonDelimiter);

            Assert.AreEqual<int>(0, result.Length, "Result count was wrong.");
        }

        [TestMethod]
        public void ParseNoValueSearchStringWithSemiColonDelimiterPlusSpace()
        {
            string[] result = SystemUnderTest.Parse(SemiColonDelimiterPlusSpace);

            Assert.AreEqual<int>(0, result.Length, "Result count was wrong.");
        }

        [TestMethod]
        public void ParseSingleValueSearchStringWithoutDelimiter()
        {
            string[] result = SystemUnderTest.Parse("mezcal");

            Assert.AreEqual<int>(1, result.Length, "Result count was wrong.");
            AssertItem(result, 0, "mezcal");
        }

        [TestMethod]
        public void ParseSingleValueSearchStringWithSemiColonDelimiter()
        {
            string[] result = SystemUnderTest.Parse("mezcal" + SemiColonDelimiter);

            Assert.AreEqual<int>(1, result.Length, "Result count was wrong.");
            AssertItem(result, 0, "mezcal");
        }

        [TestMethod]
        public void ParseSingleValueSearchStringWithSemiColonDelimiterPlusSpace()
        {
            string[] result = SystemUnderTest.Parse("mezcal" + SemiColonDelimiterPlusSpace);

            Assert.AreEqual<int>(1, result.Length, "Result count was wrong.");
            AssertItem(result, 0, "mezcal");
        }

        [TestMethod]
        public void ParseTwoValueSearchStringWithSemiColonDelimiterAndNoTrailingDelimiter()
        {
            string[] result = SystemUnderTest.Parse("mezcal" + SemiColonDelimiter + "stuff");

            Assert.AreEqual<int>(2, result.Length, "Result count was wrong.");
            AssertItem(result, 0, "mezcal");
            AssertItem(result, 1, "stuff");
        }

        [TestMethod]
        public void ParseTwoValueSearchStringWithSemiColonDelimiterPlusSpaceAndNoTrailingDelimiter()
        {
            string[] result = SystemUnderTest.Parse("mezcal" + SemiColonDelimiterPlusSpace + "stuff");

            Assert.AreEqual<int>(2, result.Length, "Result count was wrong.");
            AssertItem(result, 0, "mezcal");
            AssertItem(result, 1, "stuff");
        }

        [TestMethod]
        public void ParseTwoValueSearchStringWithSemiColonDelimiterPlusSpaceTrailingDelimiter()
        {
            string[] result = SystemUnderTest.Parse(
                "mezcal" + SemiColonDelimiterPlusSpace + "stuff" + SemiColonDelimiter);

            Assert.AreEqual<int>(2, result.Length, "Result count was wrong.");
            AssertItem(result, 0, "mezcal");
            AssertItem(result, 1, "stuff");
        }

        [TestMethod]
        public void ParseTwoValueSearchStringWithCommaDelimiterPlusSpaceTrailingDelimiter()
        {
            string[] result = SystemUnderTest.Parse(
                "mezcal" + CommaDelimiterPlusSpace + "stuff" + CommaDelimiter);

            Assert.AreEqual<int>(2, result.Length, "Result count was wrong.");
            AssertItem(result, 0, "mezcal");
            AssertItem(result, 1, "stuff");
        }
    }
}
