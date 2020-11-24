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

        protected virtual void BeforeReturnFromGet(T returnValue)
        {

        }

        protected virtual void BeforeReturnFromGet(IList<T> returnValues)
        {

        }

        protected virtual void PopulateAuditFieldsBeforeSave(T toValue)
        {
            OnPopulateAuditFieldsBeforeSave(toValue);
        }

        protected virtual void OnPopulateAuditFieldsBeforeSave(T toValue)
        {
        }

        protected virtual void PopulateAuditFieldsBeforeSave(DomainModelBase toValue)
        {
        }

        protected virtual void PopulateFieldsFromEntityAfterSave(
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

        protected virtual void PopulateFieldsFromEntityAfterSave(
            EntityBase fromValue, DomainModelBase toValue)
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
        }
    }
}
