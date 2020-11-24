using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Benday.EasyAuthDemo.Api.DataAccess.Entities;
using Benday.EfCore.SqlServer;

namespace Benday.EasyAuthDemo.Api.DataAccess.SqlServer
{
    public interface ILookupRepository : ISearchableRepository<LookupEntity>
    {
        IList<LookupEntity> GetAllByType(string lookupType);
    }
}
