using Benday.EasyAuthDemo.Api.DomainModels;
using System;

namespace Benday.EasyAuthDemo.UnitTests.Fakes
{
    public class FakeValidatorStrategy<T> : IValidatorStrategy<T>
    {
        public bool IsValidReturnValue { get; set; }

        public bool IsValid(T validateThis)
        {
            return IsValidReturnValue;
        }
    }
}
