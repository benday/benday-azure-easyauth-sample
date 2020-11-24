using Benday.EasyAuthDemo.Api.Adapters;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using Benday.EasyAuthDemo.UnitTests.Utilities;
using Benday.EasyAuthDemo.WebUi.Models;

namespace Benday.EasyAuthDemo.UnitTests.ViewModels
{
    [TestClass]
    public class PersonAdapterFixture
    {
        [TestInitialize]
        public void OnTestInitialize()
        {
            _SystemUnderTest = null;
        }

        private PersonEditorViewModelAdapter _SystemUnderTest;
        public PersonEditorViewModelAdapter SystemUnderTest
        {
            get
            {
                if (_SystemUnderTest == null)
                {
                    _SystemUnderTest = new PersonEditorViewModelAdapter();
                }

                return _SystemUnderTest;
            }
        }

        [TestMethod]
        public void AdaptPersonFromViewModelsToModels()
        {
            // arrange
            var fromValues = PersonViewModelTestUtility.CreateEditorViewModels();

            var allValuesCount = fromValues.Count;

            var toValues = new List<Benday.EasyAuthDemo.Api.DomainModels.Person>();

            // act
            SystemUnderTest.Adapt(fromValues, toValues);

            // assert
            Assert.AreEqual<int>(allValuesCount, toValues.Count, "Count was wrong.");
        }

        [TestMethod]
        public void AdaptPersonFromViewModelToModel()
        {
            // arrange
            var fromValue = PersonViewModelTestUtility.CreateEditorViewModel();
            var toValue = new Benday.EasyAuthDemo.Api.DomainModels.Person();

            // act
            SystemUnderTest.Adapt(fromValue, toValue);

            // assert
            PersonViewModelTestUtility.AssertAreEqual(fromValue, toValue);
        }

        [TestMethod]
        public void AdaptPersonFromModelToViewModel()
        {
            // arrange
            var fromValue = PersonTestUtility.CreateModel();
            var toValue = new Benday.EasyAuthDemo.WebUi.Models.PersonEditorViewModel();

            // act
            SystemUnderTest.Adapt(fromValue, toValue);

            // assert
            PersonViewModelTestUtility.AssertAreEqual(fromValue, toValue);
        }
    }
}
