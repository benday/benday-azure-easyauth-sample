using Benday.EasyAuthDemo.Api.DomainModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Benday.EasyAuthDemo.Api;
using Benday.EasyAuthDemo.Api.Adapters;

namespace Benday.EasyAuthDemo.WebUi.Models
{
    public partial class LookupEditorViewModelAdapter :
		AdapterBase<
			Benday.EasyAuthDemo.Api.DomainModels.Lookup,
			Benday.EasyAuthDemo.WebUi.Models.LookupEditorViewModel>
    {
        protected override void PerformAdapt(
			Benday.EasyAuthDemo.Api.DomainModels.Lookup fromValue, 
			Benday.EasyAuthDemo.WebUi.Models.LookupEditorViewModel toValue)
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

		protected override AdapterActions BeforeAdapt(
			Benday.EasyAuthDemo.WebUi.Models.LookupEditorViewModel fromValue,
			Benday.EasyAuthDemo.Api.DomainModels.Lookup toValue)
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
			Benday.EasyAuthDemo.WebUi.Models.LookupEditorViewModel fromValue,
			Benday.EasyAuthDemo.Api.DomainModels.Lookup toValue)
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

