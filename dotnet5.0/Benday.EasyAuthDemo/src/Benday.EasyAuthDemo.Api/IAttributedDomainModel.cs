using Benday.EasyAuthDemo.Api.DomainModels;
using System.Collections.Generic;

namespace Benday.EasyAuthDemo.Api
{
    public interface IAttributedDomainModel
    {
        List<DomainModelBase> GetAttributes();
    }
}
