using System;
using System.Collections.Generic;
using System.Linq;
using Benday.Common;
using Microsoft.EntityFrameworkCore;

namespace Benday.EfCore.SqlServer
{
    public class DependentEntityCollection<T> :
        IDependentEntityCollection where T : class, IEntityBase
    {
        private IList<T> _Entities;
        private IEntityBase _ParentEntity;

        public DependentEntityCollection(
            IEntityBase parent,
            IList<T> entities)
        {
            if (entities == null)
            {
                throw new ArgumentNullException(nameof(entities), "Argument cannot be null.");
            }

            if (entities == null)
            {
                throw new ArgumentNullException(nameof(entities), "Argument cannot be null.");
            }

            _Entities = entities;
            _ParentEntity = parent;
        }

        public void BeforeSave(DbContext dbContext)
        {
            foreach (var entity in _Entities)
            {
                if (entity.IsMarkedForDelete == true)
                {
                    RemoveFromDbSet(dbContext, entity);
                }
            }
        }

        private void RemoveFromDbSet(DbContext dbContext, T entity)
        {
            dbContext.Remove<T>(entity);
        }

        public void AfterSave()
        {
            var deleteThese = _Entities.Where(x => x.IsMarkedForDelete == true).ToList();

            deleteThese.ForEach(x => _Entities.Remove(x));
        }
    }
}
