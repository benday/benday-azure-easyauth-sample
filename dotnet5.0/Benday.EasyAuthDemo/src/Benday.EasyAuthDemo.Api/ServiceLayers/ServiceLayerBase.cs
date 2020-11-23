using System;
using System.Collections.Generic;
using System.Linq;
using Benday.EasyAuthDemo.Api.DomainModels;
using Benday.EasyAuthDemo.Api.DataAccess.Entities;
using Benday.EfCore.SqlServer;

namespace Benday.EasyAuthDemo.Api.ServiceLayers
{
    public abstract class ServiceLayerBase<T> where T : DomainModelBase
    {
        protected IUsernameProvider _UsernameProvider;

        public ServiceLayerBase(
            IUsernameProvider usernameProvider)
        {
            _UsernameProvider = usernameProvider;
        }

        protected void PopulateAuditFieldsBeforeSave(DomainModelBase toValue)
        {
            if (toValue == null)
            {
                throw new ArgumentNullException(nameof(toValue), $"{nameof(toValue)} is null.");
            }

            if (toValue.Id == 0)
            {
                toValue.CreatedBy = _UsernameProvider.GetUsername();
                toValue.CreatedDate = DateTime.UtcNow;
            }

            toValue.LastModifiedBy = _UsernameProvider.GetUsername();
            toValue.LastModifiedDate = DateTime.UtcNow;
        }

        protected void PopulateFieldsFromEntityAfterSave(
            List<EntityBase> fromValues, List<DomainModelBase> toValues)
        {
            if (fromValues == null)
            {
                throw new ArgumentNullException(nameof(fromValues));
            }

            if (toValues == null)
            {
                throw new ArgumentNullException(nameof(toValues));
            }

            if (fromValues.Count != toValues.Count)
            {
                throw new InvalidOperationException("Item count in collection doesn't match.");
            }

            for (int index = 0; index < fromValues.Count; index++)
            {
                PopulateFieldsFromEntityAfterSave(
                    fromValues[index],
                    toValues[index]);
            }
        }

        protected void PopulateAuditFieldsBeforeSave(
            List<DomainModelBase> values)
        {
            if (values != null)
            {
                foreach (var item in values)
                {
                    PopulateAuditFieldsBeforeSave(item);
                }
            }
        }

        protected void PopulateFieldsFromEntityAfterSave(
            DataAccess.Entities.EntityBase fromValue, DomainModelBase toValue)
        {
            if (fromValue == null)
            {
                throw new ArgumentNullException(nameof(fromValue), $"{nameof(fromValue)} is null.");
            }

            if (toValue == null)
            {
                throw new ArgumentNullException(nameof(toValue), $"{nameof(toValue)} is null.");
            }

            toValue.Id = fromValue.Id;
            toValue.LastModifiedDate = fromValue.LastModifiedDate;
            toValue.LastModifiedBy = fromValue.LastModifiedBy;

            toValue.CreatedDate = fromValue.CreatedDate;
            toValue.CreatedBy = fromValue.CreatedBy;
        }
    }
}
