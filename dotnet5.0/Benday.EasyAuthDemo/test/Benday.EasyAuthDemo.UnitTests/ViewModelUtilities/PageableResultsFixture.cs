using System;
using System.Collections.Generic;
using System.Linq;
using Benday.EasyAuthDemo.WebUi.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Benday.EasyAuthDemo.UnitTests.ViewModels
{
    [TestClass]
    public class PageableResultsFixture
    {
        [TestInitialize]
        public void OnTestInitialize()
        {
            _SystemUnderTest = null;
        }

        private PageableResults<string> _SystemUnderTest;
        public PageableResults<string> SystemUnderTest
        {
            get
            {
                if (_SystemUnderTest == null)
                {
                    _SystemUnderTest = new PageableResults<string>();
                }

                return _SystemUnderTest;
            }
        }

        [TestMethod]
        public void Results_WhenUninitialized_IsNotNull()
        {
            // arrange

            // act

            // assert
            Assert.IsNotNull(SystemUnderTest.Results, "Results should not be null.");
        }

        [TestMethod]
        public void TotalCount_WhenUninitialized_IsZero()
        {
            // arrange

            // act

            // assert
            Assert.AreEqual<int>(0, SystemUnderTest.TotalCount, "TotalCount be zero.");
        }

        [TestMethod]
        public void ItemsPerPage_DefaultValue()
        {
            // arrange
            int expected = 10;

            // act
            int actual = SystemUnderTest.ItemsPerPage;

            // assert
            Assert.AreEqual<int>(expected, actual, "ItemsPerPage was wrong.");
        }

        [TestMethod]
        public void TotalCountReturnsTotalOfAllRecords()
        {
            // arrange
            int expectedNumberOfRecords = 300;

            SystemUnderTest.Initialize(CreateModels(expectedNumberOfRecords));

            // act
            int actual = SystemUnderTest.TotalCount;

            // assert

            Assert.AreEqual<int>(expectedNumberOfRecords, actual,
                "TotalCount was wrong.");
        }

        [TestMethod]
        public void PageCount_NoRemainder()
        {
            // arrange
            int expectedNumberOfRecords = 300;

            SystemUnderTest.ItemsPerPage = 10;
            SystemUnderTest.Initialize(CreateModels(expectedNumberOfRecords));

            int expectedPageCount = 30;

            // act
            int actual = SystemUnderTest.PageCount;

            // assert

            Assert.AreEqual<int>(expectedPageCount, actual,
                "PageCount was wrong.");
        }

        [TestMethod]
        public void PageCount_Remainder()
        {
            // arrange
            int expectedNumberOfRecords = 305;

            SystemUnderTest.ItemsPerPage = 10;
            SystemUnderTest.Initialize(CreateModels(expectedNumberOfRecords));

            int expectedPageCount = 31;

            // act
            int actual = SystemUnderTest.PageCount;

            // assert

            Assert.AreEqual<int>(expectedPageCount, actual,
                "PageCount was wrong.");
        }

        [TestMethod]
        public void PageCount_LessThanOnePage()
        {
            // arrange
            int expectedNumberOfRecords = 5;

            SystemUnderTest.ItemsPerPage = 10;
            SystemUnderTest.Initialize(CreateModels(expectedNumberOfRecords));

            int expectedPageCount = 1;

            // act
            int actual = SystemUnderTest.PageCount;

            // assert

            Assert.AreEqual<int>(expectedPageCount, actual,
                "PageCount was wrong.");
        }

        [TestMethod]
        public void PageCount_NoRecords()
        {
            // arrange
            int expectedNumberOfRecords = 0;

            SystemUnderTest.ItemsPerPage = 10;
            SystemUnderTest.Initialize(
                CreateModels(expectedNumberOfRecords));

            int expectedPageCount = 0;

            // act
            int actual = SystemUnderTest.PageCount;

            // assert

            Assert.AreEqual<int>(expectedPageCount, actual,
                "PageCount was wrong.");
        }

        [TestMethod]
        public void CurrentPage_SetToOneOnInitialize()
        {
            // arrange
            int expectedNumberOfRecords = 305;

            SystemUnderTest.ItemsPerPage = 10;
            SystemUnderTest.Initialize(CreateModels(expectedNumberOfRecords));

            int expectedCurrentPage = 1;

            // act
            int actual = SystemUnderTest.CurrentPage;

            // assert
            Assert.AreEqual<int>(expectedCurrentPage, actual,
                "CurrentPage was wrong.");
        }

        [TestMethod]
        public void CurrentPage_SetToHigherThanPageCountSetsToHighestPage()
        {
            // arrange
            int expectedNumberOfRecords = 100;

            SystemUnderTest.ItemsPerPage = 10;
            SystemUnderTest.Initialize(CreateModels(expectedNumberOfRecords));

            int expectedCurrentPage = 10;

            // act
            SystemUnderTest.CurrentPage = 300;

            // assert
            int actual = SystemUnderTest.CurrentPage;

            Assert.AreEqual<int>(expectedCurrentPage, actual,
                "CurrentPage was wrong.");
        }

        [TestMethod]
        public void CurrentPage_SetToLowerThanPageCountSetsToOne()
        {
            // arrange
            int expectedNumberOfRecords = 100;

            SystemUnderTest.ItemsPerPage = 10;
            SystemUnderTest.Initialize(CreateModels(expectedNumberOfRecords));

            int expectedCurrentPage = 1;

            // act
            SystemUnderTest.CurrentPage = -300;

            // assert
            int actual = SystemUnderTest.CurrentPage;

            Assert.AreEqual<int>(expectedCurrentPage, actual,
                "CurrentPage was wrong.");
        }

        [TestMethod]
        public void CurrentPage_SetToValidPageNumber()
        {
            // arrange
            int expectedNumberOfRecords = 100;

            SystemUnderTest.ItemsPerPage = 10;
            SystemUnderTest.Initialize(CreateModels(expectedNumberOfRecords));

            int expectedCurrentPage = 5;

            // act
            SystemUnderTest.CurrentPage = expectedCurrentPage;

            // assert
            int actual = SystemUnderTest.CurrentPage;

            Assert.AreEqual<int>(expectedCurrentPage, actual,
                "CurrentPage was wrong.");
        }

        [TestMethod]
        public void PageValues_InitializesToPage1Values()
        {
            // arrange
            int expectedNumberOfRecords = 100;

            int expectedItemsPerPage = 10;

            SystemUnderTest.ItemsPerPage = expectedItemsPerPage;
            var allValues = CreateModels(expectedNumberOfRecords);
            SystemUnderTest.Initialize(allValues);

            var expectedPage1Values =
                allValues.Take(expectedItemsPerPage).ToList();

            // act
            var actualPageValues = SystemUnderTest.PageValues;

            // assert
            AssertAreEqual(expectedPage1Values, actualPageValues,
                "Page values was wrong.");

            Assert.AreEqual<int>(expectedItemsPerPage,
                actualPageValues.Count,
                "Number of values on page was wrong.");
        }

        private void AssertAreEqual(List<string> expected, IList<string> actual, string message)
        {
            var actualAsList = actual.ToList();

            CollectionAssert.AreEqual(expected, actualAsList, message);
        }

        [TestMethod]
        public void PageValues_ChangePageUpdatesPageValues_Page2()
        {
            // arrange
            int expectedNumberOfRecords = 100;

            int expectedItemsPerPage = 10;

            SystemUnderTest.ItemsPerPage = expectedItemsPerPage;
            List<string> allValues = CreateModels(expectedNumberOfRecords);
            SystemUnderTest.Initialize(allValues);
            
            var expectedPage2Values =
                allValues
                .Skip(expectedItemsPerPage)
                .Take(expectedItemsPerPage).ToList();

            // act
            SystemUnderTest.CurrentPage = 2;
            var actualPageValues = SystemUnderTest.PageValues;

            // assert
            AssertAreEqual(expectedPage2Values, actualPageValues,
                "Page values was wrong.");

            Assert.AreEqual<int>(expectedItemsPerPage,
                actualPageValues.Count,
                "Number of values on page was wrong.");
        }

        [TestMethod]
        public void PageValues_ChangePageUpdatesPageValues_Page3()
        {
            // arrange
            int expectedNumberOfRecords = 100;

            int expectedItemsPerPage = 10;

            SystemUnderTest.ItemsPerPage = expectedItemsPerPage;
            List<string> allValues = CreateModels(expectedNumberOfRecords);
            SystemUnderTest.Initialize(allValues);

            var expectedPage3Values =
                allValues
                .Skip(expectedItemsPerPage * 2)
                .Take(expectedItemsPerPage).ToList();

            // act
            SystemUnderTest.CurrentPage = 3;
            var actualPageValues = SystemUnderTest.PageValues;

            // assert
            AssertAreEqual(expectedPage3Values, actualPageValues,
                "Page values was wrong.");

            Assert.AreEqual<int>(expectedItemsPerPage, 
                actualPageValues.Count,
                "Number of values on page was wrong.");
        }

        [TestMethod]
        public void PageValues_ChangePageUpdatesPageValues_LastPage_Remainder()
        {
            // arrange
            int expectedNumberOfRecords = 25;

            int expectedItemsPerPage = 10;

            SystemUnderTest.ItemsPerPage = expectedItemsPerPage;
            List<string> allValues = CreateModels(expectedNumberOfRecords);
            SystemUnderTest.Initialize(allValues);

            var expectedPage3Values =
                allValues
                .Skip(expectedItemsPerPage * 2)
                .Take(expectedItemsPerPage).ToList();

            // act
            SystemUnderTest.CurrentPage = 3;
            var actualPageValues = SystemUnderTest.PageValues;

            // assert
            AssertAreEqual(expectedPage3Values, actualPageValues,
                "Page values was wrong.");
            
            Assert.AreEqual<int>(5, actualPageValues.Count, 
                "Number of values on page was wrong.");
        }

        private List<string> CreateModels(int expectedNumberOfRecords)
        {
            var returnValues = new List<string>();

            for (int i = 0; i < expectedNumberOfRecords; i++)
            {
                returnValues.Add(String.Format("item {0}", i));
            }

            return returnValues;
        }
    }
}
