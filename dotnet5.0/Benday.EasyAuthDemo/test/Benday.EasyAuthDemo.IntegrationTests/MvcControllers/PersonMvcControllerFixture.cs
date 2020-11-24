using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Benday.EasyAuthDemo.IntegrationTests.MvcControllers
{
    [TestClass]
    public class PersonWebApiControllerFixture : WebUiIntegrationTestFixtureBase
    {
        [TestMethod]
        public async Task IndexReturnsWithoutError()
        {
            // arrange
            string url = "/person";

            // act
            var response = await Client.GetAsync(url);

            // assert
            await CheckForDependencyInjectionError(response);

            Assert.IsTrue(response.IsSuccessStatusCode, 
                "Call to '{0}' failed with '{1} - '{2}'.",
                url, response.StatusCode, response.ReasonPhrase);
        }
    }
}
