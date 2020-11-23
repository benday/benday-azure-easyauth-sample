using Benday.EasyAuthDemo.Api.DomainModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Benday.EasyAuthDemo.Api;
using Benday.EasyAuthDemo.Api.Adapters;

namespace Benday.EasyAuthDemo.WebUi.Models
{
    public partial class PersonEditorViewModelAdapter :
		AdapterBase<
			Benday.EasyAuthDemo.Api.DomainModels.Person,
			Benday.EasyAuthDemo.WebUi.Models.PersonEditorViewModel>
    {
        protected override void PerformAdapt(
			Benday.EasyAuthDemo.Api.DomainModels.Person fromValue, 
			Benday.EasyAuthDemo.WebUi.Models.PersonEditorViewModel toValue)
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

		protected override AdapterActions BeforeAdapt(
			Benday.EasyAuthDemo.WebUi.Models.PersonEditorViewModel fromValue,
			Benday.EasyAuthDemo.Api.DomainModels.Person toValue)
        {
            if (fromValue == null)
            {
                return AdapterActions.Skip;
            }
            else if (fromValue.Id != ApiConstants.UnsavedId && fromValue.IsMarkedForDelete == true)
            {
                return AdapterActions.Delete;
            }
            else
            {
                return AdapterActions.Adapt;
            }
        }

		protected override void PerformAdapt(
			Benday.EasyAuthDemo.WebUi.Models.PersonEditorViewModel fromValue,
			Benday.EasyAuthDemo.Api.DomainModels.Person toValue)
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

