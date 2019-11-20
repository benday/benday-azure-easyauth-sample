using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Benday.EasyAuthDemo.Api.DataAccess.Entities;
using Benday.EfCore.SqlServer;
using Benday.EasyAuthDemo.Api;
using Benday.Common;
using System.Linq.Expressions;

namespace Benday.EasyAuthDemo.Api.DataAccess.SqlServer
{
    public partial class SqlEntityFrameworkLookupRepository : 
		SqlEntityFrameworkSearchableRepositoryBase<LookupEntity, EasyAuthDemoDbContext>, 
		ILookupRepository
    {
		public SqlEntityFrameworkLookupRepository(
            EasyAuthDemoDbContext context) : base(context)
        {

        }

        private List<string> _Includes;

        protected override List<string> Includes
        {
            get
            {
                if (_Includes == null)
                {
                    _Includes = new List<string>();

                    
                }

                return _Includes;
            }
        }

		public virtual IList<LookupEntity> GetAllByType(string lookupType)
        {
            var results = (
              from temp in EntityDbSet
              where temp.LookupType == lookupType
              select temp
            ).ToList();

            return results;
        }
		
        protected override DbSet<LookupEntity> EntityDbSet => Context.LookupEntities;

		protected override Expression<Func<LookupEntity, bool>> GetPredicateForContains(
            SearchArgument arg)
        {
			if (arg is null)
            {
                throw new ArgumentNullException(nameof(arg));
            }
            else
            {
                
				if (arg.PropertyName == nameof(LookupEntity.LookupType))
    {
        return q => q.LookupType.Contains(arg.SearchValue);
    }
else if (arg.PropertyName == nameof(LookupEntity.LookupKey))
    {
        return q => q.LookupKey.Contains(arg.SearchValue);
    }
else if (arg.PropertyName == nameof(LookupEntity.LookupValue))
    {
        return q => q.LookupValue.Contains(arg.SearchValue);
    }
else if (arg.PropertyName == nameof(LookupEntity.Status))
    {
        return q => q.Status.Contains(arg.SearchValue);
    }
else if (arg.PropertyName == nameof(LookupEntity.CreatedBy))
    {
        return q => q.CreatedBy.Contains(arg.SearchValue);
    }
else if (arg.PropertyName == nameof(LookupEntity.LastModifiedBy))
    {
        return q => q.LastModifiedBy.Contains(arg.SearchValue);
    }

				else
                {
                    throw new InvalidOperationException(
                        String.Format("Unknown argument '{0}'.", arg.PropertyName));
                }
			}
        }

		protected override Expression<Func<LookupEntity, bool>> GetPredicateForDoesNotContain(
            SearchArgument arg)
        {
            if (arg is null)
            {
                throw new ArgumentNullException(nameof(arg));
            }
            else
            {
                if (arg.PropertyName == nameof(LookupEntity.LookupType))
    {
        return q => q.LookupType.Contains(arg.SearchValue) == false;
    }
else if (arg.PropertyName == nameof(LookupEntity.LookupKey))
    {
        return q => q.LookupKey.Contains(arg.SearchValue) == false;
    }
else if (arg.PropertyName == nameof(LookupEntity.LookupValue))
    {
        return q => q.LookupValue.Contains(arg.SearchValue) == false;
    }
else if (arg.PropertyName == nameof(LookupEntity.Status))
    {
        return q => q.Status.Contains(arg.SearchValue) == false;
    }
else if (arg.PropertyName == nameof(LookupEntity.CreatedBy))
    {
        return q => q.CreatedBy.Contains(arg.SearchValue) == false;
    }
else if (arg.PropertyName == nameof(LookupEntity.LastModifiedBy))
    {
        return q => q.LastModifiedBy.Contains(arg.SearchValue) == false;
    }

				else
                {
                    throw new InvalidOperationException(
                        String.Format("Unknown argument '{0}'.", arg.PropertyName));
                }
			}
        }

		protected override Expression<Func<LookupEntity, bool>> GetPredicateForStartsWith(
            SearchArgument arg)
        {
            if (arg is null)
            {
                throw new ArgumentNullException(nameof(arg));
            }
            else
            {
                if (arg.PropertyName == nameof(LookupEntity.LookupType))
    {
        return q => q.LookupType.StartsWith(arg.SearchValue);
    }
else if (arg.PropertyName == nameof(LookupEntity.LookupKey))
    {
        return q => q.LookupKey.StartsWith(arg.SearchValue);
    }
else if (arg.PropertyName == nameof(LookupEntity.LookupValue))
    {
        return q => q.LookupValue.StartsWith(arg.SearchValue);
    }
else if (arg.PropertyName == nameof(LookupEntity.Status))
    {
        return q => q.Status.StartsWith(arg.SearchValue);
    }
else if (arg.PropertyName == nameof(LookupEntity.CreatedBy))
    {
        return q => q.CreatedBy.StartsWith(arg.SearchValue);
    }
else if (arg.PropertyName == nameof(LookupEntity.LastModifiedBy))
    {
        return q => q.LastModifiedBy.StartsWith(arg.SearchValue);
    }

				else
                {
                    throw new InvalidOperationException(
                        String.Format("Unknown argument '{0}'.", arg.PropertyName));
                }
			}
        }

		protected override Expression<Func<LookupEntity, bool>> GetPredicateForEndsWith(
            SearchArgument arg)
        {
            if (arg is null)
            {
                throw new ArgumentNullException(nameof(arg));
            }
            else
            {
                if (arg.PropertyName == nameof(LookupEntity.LookupType))
    {
        return q => 
            q.LookupType.EndsWith(arg.SearchValue);
    }
else if (arg.PropertyName == nameof(LookupEntity.LookupKey))
    {
        return q => 
            q.LookupKey.EndsWith(arg.SearchValue);
    }
else if (arg.PropertyName == nameof(LookupEntity.LookupValue))
    {
        return q => 
            q.LookupValue.EndsWith(arg.SearchValue);
    }
else if (arg.PropertyName == nameof(LookupEntity.Status))
    {
        return q => 
            q.Status.EndsWith(arg.SearchValue);
    }
else if (arg.PropertyName == nameof(LookupEntity.CreatedBy))
    {
        return q => 
            q.CreatedBy.EndsWith(arg.SearchValue);
    }
else if (arg.PropertyName == nameof(LookupEntity.LastModifiedBy))
    {
        return q => 
            q.LastModifiedBy.EndsWith(arg.SearchValue);
    }

				else
                {
                    throw new InvalidOperationException(
                        String.Format("Unknown argument '{0}'.", arg.PropertyName));
                }
			}
        }

		protected override Expression<Func<LookupEntity, bool>> GetPredicateForEquals(
            SearchArgument arg)
        {
            if (arg is null)
            {
                throw new ArgumentNullException(nameof(arg));
            }
            else
            {
                
				if (arg.PropertyName == nameof(LookupEntity.LookupType))
    {
        return q => q.LookupType == arg.SearchValue;
    }
else if (arg.PropertyName == nameof(LookupEntity.LookupKey))
    {
        return q => q.LookupKey == arg.SearchValue;
    }
else if (arg.PropertyName == nameof(LookupEntity.LookupValue))
    {
        return q => q.LookupValue == arg.SearchValue;
    }
else if (arg.PropertyName == nameof(LookupEntity.Status))
    {
        return q => q.Status == arg.SearchValue;
    }
else if (arg.PropertyName == nameof(LookupEntity.CreatedBy))
    {
        return q => q.CreatedBy == arg.SearchValue;
    }
else if (arg.PropertyName == nameof(LookupEntity.LastModifiedBy))
    {
        return q => q.LastModifiedBy == arg.SearchValue;
    }

				else
                {
                    throw new InvalidOperationException(
                        String.Format("Unknown argument '{0}'.", arg.PropertyName));
                }
			}
        }

		protected override Expression<Func<LookupEntity, bool>> GetPredicateForIsNotEqualTo(
            SearchArgument arg)
        {
            if (arg is null)
            {
                throw new ArgumentNullException(nameof(arg));
            }
            else
            {
                if (arg.PropertyName == nameof(LookupEntity.LookupType))
    {
        return q => q.LookupType == arg.SearchValue;
    }
else if (arg.PropertyName == nameof(LookupEntity.LookupKey))
    {
        return q => q.LookupKey == arg.SearchValue;
    }
else if (arg.PropertyName == nameof(LookupEntity.LookupValue))
    {
        return q => q.LookupValue == arg.SearchValue;
    }
else if (arg.PropertyName == nameof(LookupEntity.Status))
    {
        return q => q.Status == arg.SearchValue;
    }
else if (arg.PropertyName == nameof(LookupEntity.CreatedBy))
    {
        return q => q.CreatedBy == arg.SearchValue;
    }
else if (arg.PropertyName == nameof(LookupEntity.LastModifiedBy))
    {
        return q => q.LastModifiedBy == arg.SearchValue;
    }

				else
                {
                    throw new InvalidOperationException(
                        String.Format("Unknown argument '{0}'.", arg.PropertyName));
                }
			}
        }

		protected override IOrderedQueryable<LookupEntity> AddSortAscending(IOrderedQueryable<LookupEntity> query, string propertyName, bool isFirstSort)
    {
if (String.Compare(propertyName, "Id", true) == 0)
    {
		if (isFirstSort == true)
        {
            return query.OrderBy(x => x.Id);
        }
        else
        {
            return query.ThenBy(x => x.Id);
        }
    }
else if (String.Compare(propertyName, "DisplayOrder", true) == 0)
    {
		if (isFirstSort == true)
        {
            return query.OrderBy(x => x.DisplayOrder);
        }
        else
        {
            return query.ThenBy(x => x.DisplayOrder);
        }
    }
else if (String.Compare(propertyName, "LookupType", true) == 0)
    {
		if (isFirstSort == true)
        {
            return query.OrderBy(x => x.LookupType);
        }
        else
        {
            return query.ThenBy(x => x.LookupType);
        }
    }
else if (String.Compare(propertyName, "LookupKey", true) == 0)
    {
		if (isFirstSort == true)
        {
            return query.OrderBy(x => x.LookupKey);
        }
        else
        {
            return query.ThenBy(x => x.LookupKey);
        }
    }
else if (String.Compare(propertyName, "LookupValue", true) == 0)
    {
		if (isFirstSort == true)
        {
            return query.OrderBy(x => x.LookupValue);
        }
        else
        {
            return query.ThenBy(x => x.LookupValue);
        }
    }
else if (String.Compare(propertyName, "Status", true) == 0)
    {
		if (isFirstSort == true)
        {
            return query.OrderBy(x => x.Status);
        }
        else
        {
            return query.ThenBy(x => x.Status);
        }
    }
else if (String.Compare(propertyName, "CreatedBy", true) == 0)
    {
		if (isFirstSort == true)
        {
            return query.OrderBy(x => x.CreatedBy);
        }
        else
        {
            return query.ThenBy(x => x.CreatedBy);
        }
    }
else if (String.Compare(propertyName, "CreatedDate", true) == 0)
    {
		if (isFirstSort == true)
        {
            return query.OrderBy(x => x.CreatedDate);
        }
        else
        {
            return query.ThenBy(x => x.CreatedDate);
        }
    }
else if (String.Compare(propertyName, "LastModifiedBy", true) == 0)
    {
		if (isFirstSort == true)
        {
            return query.OrderBy(x => x.LastModifiedBy);
        }
        else
        {
            return query.ThenBy(x => x.LastModifiedBy);
        }
    }
else if (String.Compare(propertyName, "LastModifiedDate", true) == 0)
    {
		if (isFirstSort == true)
        {
            return query.OrderBy(x => x.LastModifiedDate);
        }
        else
        {
            return query.ThenBy(x => x.LastModifiedDate);
        }
    }
else if (String.Compare(propertyName, "Timestamp", true) == 0)
    {
		if (isFirstSort == true)
        {
            return query.OrderBy(x => x.Timestamp);
        }
        else
        {
            return query.ThenBy(x => x.Timestamp);
        }
    }
else
        {		
            throw new InvalidOperationException(
                String.Format("Unknown sort argument '{0}'.", propertyName));
		}
	}

		protected override IOrderedQueryable<LookupEntity> AddSortDescending(IOrderedQueryable<LookupEntity> query, string propertyName, bool isFirstSort)
    {
if (String.Compare(propertyName, "Id", true) == 0)
    {
		if (isFirstSort == true)
        {
            return query.OrderByDescending(x => x.Id);
        }
        else
        {
            return query.ThenByDescending(x => x.Id);
        }
    }
else if (String.Compare(propertyName, "DisplayOrder", true) == 0)
    {
		if (isFirstSort == true)
        {
            return query.OrderByDescending(x => x.DisplayOrder);
        }
        else
        {
            return query.ThenByDescending(x => x.DisplayOrder);
        }
    }
else if (String.Compare(propertyName, "LookupType", true) == 0)
    {
		if (isFirstSort == true)
        {
            return query.OrderByDescending(x => x.LookupType);
        }
        else
        {
            return query.ThenByDescending(x => x.LookupType);
        }
    }
else if (String.Compare(propertyName, "LookupKey", true) == 0)
    {
		if (isFirstSort == true)
        {
            return query.OrderByDescending(x => x.LookupKey);
        }
        else
        {
            return query.ThenByDescending(x => x.LookupKey);
        }
    }
else if (String.Compare(propertyName, "LookupValue", true) == 0)
    {
		if (isFirstSort == true)
        {
            return query.OrderByDescending(x => x.LookupValue);
        }
        else
        {
            return query.ThenByDescending(x => x.LookupValue);
        }
    }
else if (String.Compare(propertyName, "Status", true) == 0)
    {
		if (isFirstSort == true)
        {
            return query.OrderByDescending(x => x.Status);
        }
        else
        {
            return query.ThenByDescending(x => x.Status);
        }
    }
else if (String.Compare(propertyName, "CreatedBy", true) == 0)
    {
		if (isFirstSort == true)
        {
            return query.OrderByDescending(x => x.CreatedBy);
        }
        else
        {
            return query.ThenByDescending(x => x.CreatedBy);
        }
    }
else if (String.Compare(propertyName, "CreatedDate", true) == 0)
    {
		if (isFirstSort == true)
        {
            return query.OrderByDescending(x => x.CreatedDate);
        }
        else
        {
            return query.ThenByDescending(x => x.CreatedDate);
        }
    }
else if (String.Compare(propertyName, "LastModifiedBy", true) == 0)
    {
		if (isFirstSort == true)
        {
            return query.OrderByDescending(x => x.LastModifiedBy);
        }
        else
        {
            return query.ThenByDescending(x => x.LastModifiedBy);
        }
    }
else if (String.Compare(propertyName, "LastModifiedDate", true) == 0)
    {
		if (isFirstSort == true)
        {
            return query.OrderByDescending(x => x.LastModifiedDate);
        }
        else
        {
            return query.ThenByDescending(x => x.LastModifiedDate);
        }
    }
else if (String.Compare(propertyName, "Timestamp", true) == 0)
    {
		if (isFirstSort == true)
        {
            return query.OrderByDescending(x => x.Timestamp);
        }
        else
        {
            return query.ThenByDescending(x => x.Timestamp);
        }
    }
else
        {		
            throw new InvalidOperationException(
                String.Format("Unknown sort argument '{0}'.", propertyName));
		}
	}

	}
}

