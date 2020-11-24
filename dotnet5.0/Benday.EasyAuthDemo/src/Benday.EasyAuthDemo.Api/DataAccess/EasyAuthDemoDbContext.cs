using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Benday.EasyAuthDemo.Api.DataAccess.Entities;

namespace Benday.EasyAuthDemo.Api.DataAccess
{
    public class EasyAuthDemoDbContext : DbContext, IEasyAuthDemoDbContext
    {
        public EasyAuthDemoDbContext(
            DbContextOptions options) : base(options)
        {

        }

        public DbSet<PersonEntity> PersonEntities { get; set; }
        public DbSet<LookupEntity> LookupEntities { get; set; }
        public DbSet<UserClaimEntity> UserClaimEntities { get; set; }


        /*
		protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
		}
		*/
    }
}
