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
    public class LookupAdapterFixture
    {
        [TestInitialize]
        public void OnTestInitialize()
        {
            _SystemUnderTest = null;
        }

        private LookupEditorViewModelAdapter _SystemUnderTest;
        public LookupEditorViewModelAdapter SystemUnderTest
        {
            get
            {
                if (_SystemUnderTest == null)
                {
                    _SystemUnderTest = new LookupEditorViewModelAdapter();
                }

                return _SystemUnderTest;
            }
        }

        [TestMethod]
        public void AdaptLookupFromViewModelsToModels()
        {
            // arrange
            var fromValues = LookupViewModelTestUtility.CreateEditorViewModels();

            var allValuesCount = fromValues.Count;

            var toValues = new List<Benday.EasyAuthDemo.Api.DomainModels.Lookup>();

            // act
            SystemUnderTest.Adapt(fromValues, toValues);

            // assert
            Assert.AreEqual<int>(allValuesCount, toValues.Count, "Count was wrong.");
        }

        [TestMethod]
        public void AdaptLookupFromViewModelToModel()
        {
            // arrange
            var fromValue = LookupViewModelTestUtility.CreateEditorViewModel();
            var toValue = new Benday.EasyAuthDemo.Api.DomainModels.Lookup();

            // act
            SystemUnderTest.Adapt(fromValue, toValue);

            // assert
            LookupViewModelTestUtility.AssertAreEqual(fromValue, toValue);
        }

        [TestMethod]
        public void AdaptLookupFromModelToViewModel()
        {
            // arrange
            var fromValue = LookupTestUtility.CreateModel();
            var toValue = new Benday.EasyAuthDemo.WebUi.Models.LookupEditorViewModel();

            // act
            SystemUnderTest.Adapt(fromValue, toValue);

            // assert
            LookupViewModelTestUtility.AssertAreEqual(fromValue, toValue);
        }
    }
}
