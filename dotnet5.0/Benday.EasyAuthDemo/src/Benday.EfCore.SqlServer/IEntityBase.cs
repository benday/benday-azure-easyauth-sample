using Benday.Common;
using System.Collections.Generic;

namespace Benday.EfCore.SqlServer
{
    public interface IEntityBase : IInt32Identity, IDeleteable
    {
        IList<IDependentEntityCollection> GetDependentEntities();
    }
}
