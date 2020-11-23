using System;
using System.Collections.Generic;
using System.Text;

namespace Benday.EasyAuthDemo.IntegrationTests.MvcControllers
{
    public abstract class WebUiIntegrationTestFixtureBase :
        AspNetIntegrationTestFixtureBase<Benday.EasyAuthDemo.WebUi.Startup>
    {
    }
}
