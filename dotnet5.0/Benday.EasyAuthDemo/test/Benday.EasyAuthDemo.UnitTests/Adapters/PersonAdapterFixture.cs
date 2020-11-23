using Benday.EasyAuthDemo.Api.Adapters;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using Benday.EasyAuthDemo.UnitTests.Utilities;

namespace Benday.EasyAuthDemo.UnitTests.Adapters
{
    [TestClass]
    public class PersonAdapterFixture
    {
        [TestInitialize]
        public void OnTestInitialize()
        {
            _SystemUnderTest = null;
        }

        private PersonAdapter _SystemUnderTest;
        public PersonAdapter SystemUnderTest
        {
            get
            {
                if (_SystemUnderTest == null)
                {
                    _SystemUnderTest = new PersonAdapter();
                }

                return _SystemUnderTest;
            }
        }

		[TestMethod]
        public void AdaptPersonFromEntityToModel()
        {
            // arrange
            var fromValue = PersonTestUtility.CreateEntity();
            var toValue = new Benday.EasyAuthDemo.Api.DomainModels.Person();

            // act
            SystemUnderTest.Adapt(fromValue, toValue);

            // assert
            PersonTestUtility.AssertAreEqual(fromValue, toValue);
        }

        [TestMethod]
        public void AdaptPersonFromEntitiesToModels_ToEmpty()
        {
            // arrange
            var fromValues = PersonTestUtility.CreateEntities();
            var toValues = new List<Benday.EasyAuthDemo.Api.DomainModels.Person>();

            // act
            SystemUnderTest.Adapt(fromValues, toValues);

            // assert
            Assert.AreNotEqual<int>(0, toValues.Count, "There should be values.");
            PersonTestUtility.AssertAreEqual(fromValues, toValues);
        }

		[TestMethod]
        public void AdaptPersonFromEntitiesToModels_MergesByIdForExistingValues()
        {
            // arrange
            var fromValues = PersonTestUtility.CreateEntities(false);

            foreach (var fromValue in fromValues)
            {
                Assert.AreNotEqual<int>(0, fromValue.Id, "Value wasn't 'saved' before start of test.");
            }
            
            int expectedCount = fromValues.Count;
            
            var toValues = new List<Benday.EasyAuthDemo.Api.DomainModels.Person>();
            
            // adapt first time
            SystemUnderTest.Adapt(fromValues, toValues);

            var originalValuesById = GetOriginalValuesById(toValues);

            // act
            // call adapt again
            SystemUnderTest.Adapt(fromValues, toValues);

            // assert
            Assert.AreNotEqual<int>(0, toValues.Count, "There should be values.");
            AssertValuesStillExistAndIdDidNotChange(toValues, originalValuesById);
            PersonTestUtility.AssertAreEqual(fromValues, toValues);
        }

        private void AssertValuesStillExistAndIdDidNotChange(
            List<Benday.EasyAuthDemo.Api.DomainModels.Person> actualValues, 
            Dictionary<int, Benday.EasyAuthDemo.Api.DomainModels.Person> expectedValuesById)
        {
            Assert.AreEqual<int>(expectedValuesById.Count, actualValues.Count, "Item count changed.");

            Benday.EasyAuthDemo.Api.DomainModels.Person expected;

            foreach (var expectedId in expectedValuesById.Keys)
            {
                expected = expectedValuesById.GetValueOrDefault(expectedId);

                Assert.IsNotNull(expected, "Expected value should not be null.");

                Assert.AreEqual<int>(expectedId, expected.Id, "Id value should not have changed.");

                Assert.IsTrue(actualValues.Contains(expected), "Value should exist in actual values.");
            }
        }

        private Dictionary<int, Benday.EasyAuthDemo.Api.DomainModels.Person> GetOriginalValuesById(
            List<Benday.EasyAuthDemo.Api.DomainModels.Person> values)
        {
            var originalValuesById = 
                new Dictionary<int, Benday.EasyAuthDemo.Api.DomainModels.Person>();

            foreach (var item in values)
            {
                originalValuesById.Add(item.Id, item);
            }

            return originalValuesById;
        }

		[TestMethod]
        public void AdaptPersonFromModelToEntity()
        {
            // arrange
            var fromValue = PersonTestUtility.CreateModel();
            var toValue = new Benday.EasyAuthDemo.Api.DataAccess.Entities.PersonEntity();

            // act
            SystemUnderTest.Adapt(fromValue, toValue);

            // assert
            PersonTestUtility.AssertAreEqual(fromValue, toValue);
        }

        [TestMethod]
        public void AdaptPersonFromModelsToEntities_ToEmpty()
        {
            // arrange
            var fromValues = PersonTestUtility.CreateModels();
            var toValues = new List<Benday.EasyAuthDemo.Api.DataAccess.Entities.PersonEntity>();

            // act
            SystemUnderTest.Adapt(fromValues, toValues);

            // assert
            Assert.AreNotEqual<int>(0, toValues.Count, "There should be values.");
            PersonTestUtility.AssertAreEqual(fromValues, toValues);
        }

		[TestMethod]
        public void AdaptPersonFromModelsToEntities_MergesByIdForExistingValues()
        {
            // arrange
            var fromValues = PersonTestUtility.CreateModels(false);
            var toValues = new List<Benday.EasyAuthDemo.Api.DataAccess.Entities.PersonEntity>();

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
            PersonTestUtility.AssertAreEqual(fromValues, toValues);
        }

        private void AssertValuesStillExistAndIdDidNotChange(
            List<Benday.EasyAuthDemo.Api.DataAccess.Entities.PersonEntity> actualValues,
            Dictionary<int, Benday.EasyAuthDemo.Api.DataAccess.Entities.PersonEntity> expectedValuesById)
        {
            Assert.AreEqual<int>(expectedValuesById.Count, actualValues.Count, "Item count changed.");

            Benday.EasyAuthDemo.Api.DataAccess.Entities.PersonEntity expected;

            foreach (var expectedId in expectedValuesById.Keys)
            {
                expected = expectedValuesById.GetValueOrDefault(expectedId);

                Assert.IsNotNull(expected, "Expected value should not be null.");

                Assert.AreEqual<int>(expectedId, expected.Id, "Id value should not have changed.");

                Assert.IsTrue(actualValues.Contains(expected), "Value should exist in actual values.");
            }
        }

        private Dictionary<int, Benday.EasyAuthDemo.Api.DataAccess.Entities.PersonEntity> GetOriginalValuesById(
            List<Benday.EasyAuthDemo.Api.DataAccess.Entities.PersonEntity> values)
        {
            var originalValuesById =
                new Dictionary<int, Benday.EasyAuthDemo.Api.DataAccess.Entities.PersonEntity>();

            foreach (var item in values)
            {
                originalValuesById.Add(item.Id, item);
            }

            return originalValuesById;
        }
    }
}
