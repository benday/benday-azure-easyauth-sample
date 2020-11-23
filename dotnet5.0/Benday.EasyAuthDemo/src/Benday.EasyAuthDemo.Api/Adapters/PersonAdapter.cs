using Benday.EasyAuthDemo.Api.DomainModels;
using Benday.EasyAuthDemo.Api.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Benday.EasyAuthDemo.Api.Adapters
{
    public partial class PersonAdapter : 
		AdapterBase<
			Benday.EasyAuthDemo.Api.DomainModels.Person,
			Benday.EasyAuthDemo.Api.DataAccess.Entities.PersonEntity>
    {
		
        
        protected override void PerformAdapt(
			Benday.EasyAuthDemo.Api.DomainModels.Person fromValue, 
			Benday.EasyAuthDemo.Api.DataAccess.Entities.PersonEntity toValue)
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
toValue.FirstName = fromValue.FirstName;
toValue.LastName = fromValue.LastName;
toValue.PhoneNumber = fromValue.PhoneNumber;
toValue.EmailAddress = fromValue.EmailAddress;
toValue.Status = fromValue.Status;
toValue.CreatedBy = fromValue.CreatedBy;
toValue.CreatedDate = fromValue.CreatedDate;
toValue.LastModifiedBy = fromValue.LastModifiedBy;
toValue.LastModifiedDate = fromValue.LastModifiedDate;
toValue.Timestamp = fromValue.Timestamp;

			
        }
		
		protected override void PerformAdapt(
			Benday.EasyAuthDemo.Api.DataAccess.Entities.PersonEntity fromValue,
			Benday.EasyAuthDemo.Api.DomainModels.Person toValue
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
toValue.FirstName = fromValue.FirstName;
toValue.LastName = fromValue.LastName;
toValue.PhoneNumber = fromValue.PhoneNumber;
toValue.EmailAddress = fromValue.EmailAddress;
toValue.Status = fromValue.Status;
toValue.CreatedBy = fromValue.CreatedBy;
toValue.CreatedDate = fromValue.CreatedDate;
toValue.LastModifiedBy = fromValue.LastModifiedBy;
toValue.LastModifiedDate = fromValue.LastModifiedDate;
toValue.Timestamp = fromValue.Timestamp;

			
        }
    }
}
