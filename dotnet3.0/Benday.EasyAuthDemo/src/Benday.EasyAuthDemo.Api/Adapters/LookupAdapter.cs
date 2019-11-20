using Benday.EasyAuthDemo.Api.DomainModels;
using Benday.EasyAuthDemo.Api.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Benday.EasyAuthDemo.Api.Adapters
{
    public partial class LookupAdapter : 
		AdapterBase<
			Benday.EasyAuthDemo.Api.DomainModels.Lookup,
			Benday.EasyAuthDemo.Api.DataAccess.Entities.LookupEntity>
    {
		
        
        protected override void PerformAdapt(
			Benday.EasyAuthDemo.Api.DomainModels.Lookup fromValue, 
			Benday.EasyAuthDemo.Api.DataAccess.Entities.LookupEntity toValue)
        {
            if (fromValue == null)
            {
                throw new ArgumentNullException(nameof(fromValue));
            }

            if (toValue == null)
            {
                throw new ArgumentNullException(nameof(toValue));
            }

            toValue.Id = fromValue.Id;
toValue.DisplayOrder = fromValue.DisplayOrder;
toValue.LookupType = fromValue.LookupType;
toValue.LookupKey = fromValue.LookupKey;
toValue.LookupValue = fromValue.LookupValue;
toValue.Status = fromValue.Status;
toValue.CreatedBy = fromValue.CreatedBy;
toValue.CreatedDate = fromValue.CreatedDate;
toValue.LastModifiedBy = fromValue.LastModifiedBy;
toValue.LastModifiedDate = fromValue.LastModifiedDate;
toValue.Timestamp = fromValue.Timestamp;

			
        }
		
		protected override void PerformAdapt(
			Benday.EasyAuthDemo.Api.DataAccess.Entities.LookupEntity fromValue,
			Benday.EasyAuthDemo.Api.DomainModels.Lookup toValue
			)
        {
            if (fromValue == null)
            {
                throw new ArgumentNullException(nameof(fromValue));
            }

            if (toValue == null)
            {
                throw new ArgumentNullException(nameof(toValue));
            }

            toValue.Id = fromValue.Id;
toValue.DisplayOrder = fromValue.DisplayOrder;
toValue.LookupType = fromValue.LookupType;
toValue.LookupKey = fromValue.LookupKey;
toValue.LookupValue = fromValue.LookupValue;
toValue.Status = fromValue.Status;
toValue.CreatedBy = fromValue.CreatedBy;
toValue.CreatedDate = fromValue.CreatedDate;
toValue.LastModifiedBy = fromValue.LastModifiedBy;
toValue.LastModifiedDate = fromValue.LastModifiedDate;
toValue.Timestamp = fromValue.Timestamp;

			
        }
    }
}
