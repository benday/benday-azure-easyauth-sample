using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Benday.EasyAuthDemo.Api.DataAccess.Entities;

namespace Benday.EasyAuthDemo.Api.DataAccess
{
    public interface IEasyAuthDemoDbContext
    {
        DbSet<PersonEntity> PersonEntities { get; set; }
        DbSet<LookupEntity> LookupEntities { get; set; }
        DbSet<UserClaimEntity> UserClaimEntities { get; set; }

    }
}
