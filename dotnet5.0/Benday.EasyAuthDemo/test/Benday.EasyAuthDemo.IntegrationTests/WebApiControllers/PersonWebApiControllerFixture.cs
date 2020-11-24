//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using System;
//using System.Collections.Generic;
//using System.Text;
//using System.Threading.Tasks;

//namespace Benday.EasyAuthDemo.IntegrationTests.WebApiControllers
//{
//    [TestClass]
//    public class PersonWebApiControllerFixture : WebApiIntegrationTestFixtureBase
//    {
//        [TestMethod]
//        public async Task GetAllReturnsWithoutError()
//        {
//            // arrange
//            string url = "/api/person";

//            // act
//            var response = await Client.GetAsync(url);

//            // assert
//            await CheckForDependencyInjectionError(response);

//            Assert.IsTrue(response.IsSuccessStatusCode, 
//                "Call to '{0}' failed with '{1} - '{2}'.",
//                url, response.StatusCode, response.ReasonPhrase);
//        }
//    }
//}
