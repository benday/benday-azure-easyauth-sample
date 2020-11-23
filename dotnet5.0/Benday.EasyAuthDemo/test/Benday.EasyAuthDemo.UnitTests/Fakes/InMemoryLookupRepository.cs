using Benday.EasyAuthDemo.Api.DataAccess.Entities;
using Benday.EasyAuthDemo.Api.DataAccess.SqlServer;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Benday.EasyAuthDemo.UnitTests.Fakes
{
    public class InMemoryLookupRepository : InMemoryRepository<LookupEntity>, ILookupRepository
    {
        public IList<LookupEntity> GetAllByType(string lookupType)
        {
            return (from temp in Items
                    where temp.LookupType == lookupType
                    select temp).ToList();
        }
    }
}
