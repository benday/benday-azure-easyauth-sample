//using System;
//using System.Collections.Generic;
//using System.Text;
//using System.Linq;
//using Benday.EasyAuthDemo.Api.DomainModels;
//using Benday.EasyAuthDemo.Api.Adapters;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using Benday.EasyAuthDemo.UnitTests.Fakes;
//using Benday.EasyAuthDemo.UnitTests.Utilities;
//using Benday.EasyAuthDemo.WebApi.Controllers;

//namespace Benday.EasyAuthDemo.UnitTests.WebApiControllers
//{
//	[TestClass]
//    public class LookupControllerFixture
//    {
//		[TestInitialize]
//        public void OnTestInitialize()
//        {
//            _SystemUnderTest = null;
//            _LookupServiceInstance = null;
//        }

//		private Benday.EasyAuthDemo.WebApi.Controllers.LookupController _SystemUnderTest;

//        private Benday.EasyAuthDemo.WebApi.Controllers.LookupController SystemUnderTest
//        {
//            get
//            {
//                if (_SystemUnderTest == null)
//                {
//                    _SystemUnderTest = 
//                        new Benday.EasyAuthDemo.WebApi.Controllers.LookupController(
//                            LookupServiceInstance);
//                }

//                return _SystemUnderTest;
//            }
//        }


//		private FakeLookupService _LookupServiceInstance;
//        public FakeLookupService LookupServiceInstance
//        {
//            get
//            {
//                if (_LookupServiceInstance == null)
//                {
//                    _LookupServiceInstance = 
//						new FakeLookupService();
//                }

//                return _LookupServiceInstance;
//            }
//        }
//		[TestMethod]
//        public void LookupController_GetLookups_CallsServiceAndReturnsList()
//        {
//            // arrange
//            var expected = LookupTestUtility.CreateModels();

//            LookupServiceInstance.GetAllReturnValue = expected;

//            // act
//            var actual = SystemUnderTest.GetLookups();

//            // assert
//            Assert.IsNotNull(actual, "Return value was null.");
//            Assert.AreSame(expected, actual, "Did not return the expected instance.");
//            Assert.IsTrue(LookupServiceInstance.WasGetAllCalled, "GetAll was not called.");
//        }

//        [TestMethod]
//        public void LookupController_GetLookup_ForKnownValueCallsServiceAndReturnsValue()
//        {
//            // arrange
//            var expected = LookupTestUtility.CreateModel();

//            LookupServiceInstance.GetByIdReturnValue = expected;

//            // act
//            var actual =
//                UnitTestUtility.GetModel<Lookup>(
//                    SystemUnderTest.GetLookup(1234));

//            // assert
//            Assert.IsNotNull(actual, "Return value was null.");
//            Assert.AreSame(expected, actual, "Did not return the expected instance.");
//            Assert.IsTrue(LookupServiceInstance.WasGetByIdCalled, "GetById was not called.");
//        }

//        [TestMethod]
//        public void LookupController_GetLookup_ForUnknownValueReturnsNotFound()
//        {
//            // arrange
//            LookupServiceInstance.GetByIdReturnValue = null;

//            // act
//            var actual = SystemUnderTest.GetLookup(1234);

//            // assert
//            Assert.IsNotNull(actual, "Return value was null.");
//            UnitTestUtility.AssertIsHttpNotFound(actual);
//            Assert.IsTrue(LookupServiceInstance.WasGetByIdCalled, "GetById was not called.");
//        }

//        [TestMethod]
//        public void LookupController_PostLookup_SavesAndReturnsCreatedAtActionResultWithNewId()
//        {
//            // arrange
//            var saveThis = LookupTestUtility.CreateModel(true);
//            LookupServiceInstance.OnSaveUpdateId = true;

//            // act
//            var actual = SystemUnderTest.PostLookup(saveThis);

//            // assert
//            var model = UnitTestUtility.AssertCreatedAtActionResultAndReturnModel<Lookup>(
//                actual,
//                LookupServiceInstance.OnSaveUpdateIdToThisValue,
//                saveThis);

//            Assert.IsTrue(LookupServiceInstance.WasSaveCalled, "Save was not called.");
//            Assert.AreSame(model, LookupServiceInstance.SaveArgumentValue, "Wrong value was saved.");
//        }

//        [TestMethod]
//        public void LookupController_PutLookup_SavesAndReturnsNoLookup()
//        {
//            // arrange
//            var saveThis = LookupTestUtility.CreateModel();

//            // act
//            var actual = SystemUnderTest.PutLookup(saveThis.Id, saveThis);

//            // assert
//            UnitTestUtility.AssertIsNoContentResult(actual);
//            Assert.IsTrue(LookupServiceInstance.WasSaveCalled, "Save was not called.");
//            Assert.AreSame(saveThis, LookupServiceInstance.SaveArgumentValue, "Wrong value was saved.");
//        }

//        [TestMethod]
//        public void LookupController_PutLookup_ReturnsBadRequestWhenIdDoesNotMatchData()
//        {
//            // arrange
//            var saveThis = LookupTestUtility.CreateModel();

//            // act
//            var actual = SystemUnderTest.PutLookup(saveThis.Id + 1, saveThis);

//            // assert
//            UnitTestUtility.AssertIsBadRequest(actual);
//            Assert.IsFalse(LookupServiceInstance.WasSaveCalled, "Save should not be called.");
//        }

//        [TestMethod]
//        public void LookupController_DeleteLookup_ForKnownValueCallsServiceAndReturnsValue()
//        {
//            // arrange
//            var expected = LookupTestUtility.CreateModel();
//            LookupServiceInstance.GetByIdReturnValue = expected;

//            // act
//            var actual =
//                UnitTestUtility.GetModel<Lookup>(
//                    SystemUnderTest.DeleteLookup(1234));

//            // assert
//            Assert.IsNotNull(actual, "Return value was null.");
//            Assert.AreSame(expected, actual, "Did not return the expected instance.");
//            Assert.IsTrue(LookupServiceInstance.WasGetByIdCalled, "GetById was not called.");
//            Assert.IsTrue(LookupServiceInstance.WasDeleteByIdCalled, "DeleteById was not called.");
//        }

//        [TestMethod]
//        public void LookupController_DeleteLookup_ForUnknownValueReturnsNotFound()
//        {
//            // arrange
//            LookupServiceInstance.GetByIdReturnValue = null;

//            // act
//            var actual = SystemUnderTest.DeleteLookup(1234);

//            // assert
//            Assert.IsNotNull(actual, "Return value was null.");
//            UnitTestUtility.AssertIsHttpNotFound(actual);
//            Assert.IsTrue(LookupServiceInstance.WasGetByIdCalled, "GetById was not called.");
//            Assert.IsFalse(LookupServiceInstance.WasDeleteByIdCalled, 
//                "DeleteById should not be called.");
//        }		
//	    [TestMethod]
//        public void LookupController_GetAllByType_ForKnownValueCallsServiceAndReturnsValue()
//        {
//            // arrange
//            var expected = LookupTestUtility.CreateModels();

//            LookupServiceInstance.GetAllByTypeReturnValue = expected;

//            // act
//            var actual = SystemUnderTest.GetLookupsByType("1234");

//            // assert
//            Assert.IsNotNull(actual, "Return value was null.");
//            Assert.AreSame(expected, actual, "Did not return the expected instance.");
//            Assert.IsTrue(LookupServiceInstance.WasGetAllByTypeCalled, "GetLookupsByType was not called.");
//        }
//    }
//}

