using Benday.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace Benday.EfCore.SqlServer
{
    public abstract class SqlEntityFrameworkRepositoryBase<TEntity, TDbContext> :
        IDisposable where TEntity : class, IEntityBase
        where TDbContext : DbContext
    {
        protected SqlEntityFrameworkRepositoryBase(
            TDbContext context)
        {
            if (context == null)
                throw new ArgumentNullException("context", "context is null.");

            _Context = context;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private bool _IsDisposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (_IsDisposed) return;

            if (disposing)
            {
                // free managed resources
                ((IDisposable)_Context).Dispose();
            }

            _IsDisposed = true;
        }

        private TDbContext _Context;

        protected TDbContext Context
        {
            get
            {
                return _Context;
            }
        }

        protected void VerifyItemIsAddedOrAttachedToDbSet(DbSet<TEntity> dbset, TEntity item)
        {
            if (item == null)
            {
                return;
            }
            else
            {
                if (item.Id == 0)
                {
                    dbset.Add(item);
                }
                else
                {
                    var entry = _Context.Entry<TEntity>(item);

                    if (entry.State == EntityState.Detached)
                    {
                        dbset.Attach(item);
                    }

                    entry.State = EntityState.Modified;
                }
            }
        }
    }
}
