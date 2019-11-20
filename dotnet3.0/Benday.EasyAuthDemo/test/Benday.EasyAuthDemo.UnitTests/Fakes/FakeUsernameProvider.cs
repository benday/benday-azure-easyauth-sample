using Benday.EasyAuthDemo.Api;
using System;

namespace Benday.EasyAuthDemo.UnitTests.Fakes
{
    public class FakeUsernameProvider : IUsernameProvider
    {
        public string GetUsernameReturnValue { get; set; }

        public string GetUsername()
        {
            return GetUsernameReturnValue;
        }
    }
}
