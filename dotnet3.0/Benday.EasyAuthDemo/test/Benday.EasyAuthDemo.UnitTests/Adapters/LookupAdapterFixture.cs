using Benday.EasyAuthDemo.Api.Adapters;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using Benday.EasyAuthDemo.UnitTests.Utilities;

namespace Benday.EasyAuthDemo.UnitTests.Adapters
{
    [TestClass]
    public class LookupAdapterFixture
    {
        [TestInitialize]
        public void OnTestInitialize()
        {
            _SystemUnderTest = null;
        }

        private LookupAdapter _SystemUnderTest;
        public LookupAdapter SystemUnderTest
        {
            get
            {
                if (_SystemUnderTest == null)
                {
                    _SystemUnderTest = new LookupAdapter();
                }

                return _SystemUnderTest;
            }
        }

		[TestMethod]
        public void AdaptLookupFromEntityToModel()
        {
            // arrange
            var fromValue = LookupTestUtility.CreateEntity();
            var toValue = new Benday.EasyAuthDemo.Api.DomainModels.Lookup();

            // act
            SystemUnderTest.Adapt(fromValue, toValue);

            // assert
            LookupTestUtility.AssertAreEqual(fromValue, toValue);
        }

        [TestMethod]
        public void AdaptLookupFromEntitiesToModels_ToEmpty()
        {
            // arrange
            var fromValues = LookupTestUtility.CreateEntities();
            var toValues = new List<Benday.EasyAuthDemo.Api.DomainModels.Lookup>();

            // act
            SystemUnderTest.Adapt(fromValues, toValues);

            // assert
            Assert.AreNotEqual<int>(0, toValues.Count, "There should be values.");
            LookupTestUtility.AssertAreEqual(fromValues, toValues);
        }

		[TestMethod]
        public void AdaptLookupFromEntitiesToModels_MergesByIdForExistingValues()
        {
            // arrange
            var fromValues = LookupTestUtility.CreateEntities(false);

            foreach (var fromValue in fromValues)
            {
                Assert.AreNotEqual<int>(0, fromValue.Id, "Value wasn't 'saved' before start of test.");
            }
            
            int expectedCount = fromValues.Count;
            
            var toValues = new List<Benday.EasyAuthDemo.Api.DomainModels.Lookup>();
            
            // adapt first time
            SystemUnderTest.Adapt(fromValues, toValues);

            var originalValuesById = GetOriginalValuesById(toValues);

            // act
            // call adapt again
            SystemUnderTest.Adapt(fromValues, toValues);

            // assert
            Assert.AreNotEqual<int>(0, toValues.Count, "There should be values.");
            AssertValuesStillExistAndIdDidNotChange(toValues, originalValuesById);
            LookupTestUtility.AssertAreEqual(fromValues, toValues);
        }

        private void AssertValuesStillExistAndIdDidNotChange(
            List<Benday.EasyAuthDemo.Api.DomainModels.Lookup> actualValues, 
            Dictionary<int, Benday.EasyAuthDemo.Api.DomainModels.Lookup> expectedValuesById)
        {
            Assert.AreEqual<int>(expectedValuesById.Count, actualValues.Count, "Item count changed.");

            Benday.EasyAuthDemo.Api.DomainModels.Lookup expected;

            foreach (var expectedId in expectedValuesById.Keys)
            {
                expected = expectedValuesById.GetValueOrDefault(expectedId);

                Assert.IsNotNull(expected, "Expected value should not be null.");

                Assert.AreEqual<int>(expectedId, expected.Id, "Id value should not have changed.");

                Assert.IsTrue(actualValues.Contains(expected), "Value should exist in actual values.");
            }
        }

        private Dictionary<int, Benday.EasyAuthDemo.Api.DomainModels.Lookup> GetOriginalValuesById(
            List<Benday.EasyAuthDemo.Api.DomainModels.Lookup> values)
        {
            var originalValuesById = 
                new Dictionary<int, Benday.EasyAuthDemo.Api.DomainModels.Lookup>();

            foreach (var item in values)
            {
                originalValuesById.Add(item.Id, item);
            }

            return originalValuesById;
        }

		[TestMethod]
        public void AdaptLookupFromModelToEntity()
        {
            // arrange
            var fromValue = LookupTestUtility.CreateModel();
            var toValue = new Benday.EasyAuthDemo.Api.DataAccess.Entities.LookupEntity();

            // act
            SystemUnderTest.Adapt(fromValue, toValue);

            // assert
            LookupTestUtility.AssertAreEqual(fromValue, toValue);
        }

        [TestMethod]
        public void AdaptLookupFromModelsToEntities_ToEmpty()
        {
            // arrange
            var fromValues = LookupTestUtility.CreateModels();
            var toValues = new List<Benday.EasyAuthDemo.Api.DataAccess.Entities.LookupEntity>();

            // act
            SystemUnderTest.Adapt(fromValues, toValues);

            // assert
            Assert.AreNotEqual<int>(0, toValues.Count, "There should be values.");
            LookupTestUtility.AssertAreEqual(fromValues, toValues);
        }

		[TestMethod]
        public void AdaptLookupFromModelsToEntities_MergesByIdForExistingValues()
        {
            // arrange
            var fromValues = LookupTestUtility.CreateModels(false);
            var toValues = new List<Benday.EasyAuthDemo.Api.DataAccess.Entities.LookupEntity>();

            foreach (var fromValue in fromValues)
            {
                Assert.AreNotEqual<int>(0, fromValue.Id, "Value wasn't 'saved' before start of test.");
            }

            int expectedCount = fromValues.Count;

            // adapt first time
            SystemUnderTest.Adapt(fromValues, toValues);

            var originalValuesById = GetOriginalValuesById(toValues);

            // act
            // call adapt again
            SystemUnderTest.Adapt(fromValues, toValues);

            // assert
            Assert.AreNotEqual<int>(0, toValues.Count, "There should be values.");
            AssertValuesStillExistAndIdDidNotChange(toValues, originalValuesById);
            LookupTestUtility.AssertAreEqual(fromValues, toValues);
        }

        private void AssertValuesStillExistAndIdDidNotChange(
            List<Benday.EasyAuthDemo.Api.DataAccess.Entities.LookupEntity> actualValues,
            Dictionary<int, Benday.EasyAuthDemo.Api.DataAccess.Entities.LookupEntity> expectedValuesById)
        {
            Assert.AreEqual<int>(expectedValuesById.Count, actualValues.Count, "Item count changed.");

            Benday.EasyAuthDemo.Api.DataAccess.Entities.LookupEntity expected;

            foreach (var expectedId in expectedValuesById.Keys)
            {
                expected = expectedValuesById.GetValueOrDefault(expectedId);

                Assert.IsNotNull(expected, "Expected value should not be null.");

                Assert.AreEqual<int>(expectedId, expected.Id, "Id value should not have changed.");

                Assert.IsTrue(actualValues.Contains(expected), "Value should exist in actual values.");
            }
        }

        private Dictionary<int, Benday.EasyAuthDemo.Api.DataAccess.Entities.LookupEntity> GetOriginalValuesById(
            List<Benday.EasyAuthDemo.Api.DataAccess.Entities.LookupEntity> values)
        {
            var originalValuesById =
                new Dictionary<int, Benday.EasyAuthDemo.Api.DataAccess.Entities.LookupEntity>();

            foreach (var item in values)
            {
                originalValuesById.Add(item.Id, item);
            }

            return originalValuesById;
        }
    }
}
