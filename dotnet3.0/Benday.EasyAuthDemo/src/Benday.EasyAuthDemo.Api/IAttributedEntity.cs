using Benday.EasyAuthDemo.Api.DataAccess.Entities;
using System.Collections.Generic;

namespace Benday.EasyAuthDemo.Api
{
    public interface IAttributedEntity
    {
        List<EntityBase> GetAttributes();
    }
}
