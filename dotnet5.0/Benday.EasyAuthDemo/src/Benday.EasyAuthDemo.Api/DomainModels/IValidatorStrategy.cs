using System;

namespace Benday.EasyAuthDemo.Api.DomainModels
{
    public interface IValidatorStrategy<T>
    {
        bool IsValid(T validateThis);
    }
}
