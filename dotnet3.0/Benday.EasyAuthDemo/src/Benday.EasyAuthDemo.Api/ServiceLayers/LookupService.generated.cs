using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Benday.EasyAuthDemo.Api.Adapters;
using Benday.EasyAuthDemo.Api.DomainModels;
using Benday.EfCore.SqlServer;
using Benday.Common;
using Benday.EasyAuthDemo.Api.DataAccess.Entities;
using Benday.EasyAuthDemo.Api.DataAccess.SqlServer;

namespace Benday.EasyAuthDemo.Api.ServiceLayers
{
    public partial class LookupService : 
            ServiceLayerBase<Benday.EasyAuthDemo.Api.DomainModels.Lookup>, 
            ILookupService
    {
		private ILookupRepository _Repository;
        private LookupAdapter _Adapter;
        private IValidatorStrategy<Benday.EasyAuthDemo.Api.DomainModels.Lookup> _ValidatorInstance;        
        private ISearchStringParserStrategy _SearchStringParser;

        public LookupService(
			ILookupRepository repository,
			IValidatorStrategy<Benday.EasyAuthDemo.Api.DomainModels.Lookup> validator,
            IUsernameProvider usernameProvider, ISearchStringParserStrategy searchStringParser) :
            base(usernameProvider)
        {
            _Repository = repository;
            _ValidatorInstance = validator;
            _SearchStringParser = searchStringParser;
            
            _Adapter = new LookupAdapter();
        }

        public IList<Benday.EasyAuthDemo.Api.DomainModels.Lookup> GetAll(
			int maxNumberOfResults = 100)
        {
            var entityResults = _Repository.GetAll(maxNumberOfResults);

            var returnValues = new List<Benday.EasyAuthDemo.Api.DomainModels.Lookup>();

            _Adapter.Adapt(entityResults, returnValues);

            return returnValues;
        }
        
        public Benday.EasyAuthDemo.Api.DomainModels.Lookup GetById(int id)
        {
            var entityResults = _Repository.GetById(id);

            if (entityResults == null)
            {
                return null;
            }
            else
            {
                var returnValues = new Benday.EasyAuthDemo.Api.DomainModels.Lookup();

                _Adapter.Adapt(entityResults, returnValues);

                return returnValues;
            }
        }

		public void Save(Benday.EasyAuthDemo.Api.DomainModels.Lookup saveThis)
        {
            if (saveThis == null)
                throw new ArgumentNullException("saveThis", "saveThis is null.");

            if (_ValidatorInstance.IsValid(saveThis) == false)
            {
                ApiUtilities.ThrowValidationException(saveThis, "Item is invalid.");
            }
            else
            {
                Benday.EasyAuthDemo.Api.DataAccess.Entities.LookupEntity toValue;

                if (saveThis.Id == 0)
                {
                    toValue = new Benday.EasyAuthDemo.Api.DataAccess.Entities.LookupEntity();
                }
                else
                {
                    toValue = _Repository.GetById(saveThis.Id);

                    if (toValue == null)
                    {
                        ApiUtilities.ThrowUnknownObjectException("Lookup", saveThis.Id);
                    }
                }

                PopulateAuditFieldsBeforeSave(saveThis);
				
				

                _Adapter.Adapt(saveThis, toValue);

                _Repository.Save(toValue);

                PopulateFieldsFromEntityAfterSave(toValue, saveThis);				
				
				
            }
        }

        public void DeleteById(int id)
        {
            var match = _Repository.GetById(id);

            if (match == null)
            {
                throw new InvalidOperationException(
                        $"Could not locate an item with an id of '{id}'."
                        );
            }
            else
            {
                _Repository.Delete(match);
            }
        }

		public IList<Benday.EasyAuthDemo.Api.DomainModels.Lookup> SimpleSearch(
			string searchValue, 
			string sortBy = null,
			string sortByDirection = null, 
			int maxNumberOfResults = 100)
        {
			Search search = GetSimpleSearch(searchValue, maxNumberOfResults);
						
			if (sortBy != null)
			{
				search.AddSort(sortBy, sortByDirection);
			}

			return Search(search);
        }

		private Search GetSimpleSearch(string searchValue, int maxNumberOfResults)
		{
			var search = new Search();

			search.MaxNumberOfResults = maxNumberOfResults;

            var searchTokens = _SearchStringParser.Parse(searchValue);

            foreach (var searchToken in searchTokens)
            {
                AddSimpleSearchForValue(search, searchToken);
            }

			return search;
		}

        private void AddSimpleSearchForValue(Search search, string searchValue)
        {
			search.AddArgument(
        "LookupType", SearchMethod.Contains, searchValue, SearchOperator.Or);
search.AddArgument(
        "LookupKey", SearchMethod.Contains, searchValue, SearchOperator.Or);
search.AddArgument(
        "LookupValue", SearchMethod.Contains, searchValue, SearchOperator.Or);
search.AddArgument(
        "Status", SearchMethod.Contains, searchValue, SearchOperator.Or);
search.AddArgument(
        "CreatedBy", SearchMethod.Contains, searchValue, SearchOperator.Or);
search.AddArgument(
        "LastModifiedBy", SearchMethod.Contains, searchValue, SearchOperator.Or);

			
        }

		public IList<Benday.EasyAuthDemo.Api.DomainModels.Lookup> Search(
			SearchMethod searchTypeLookupType = SearchMethod.Contains,
			string searchValueLookupType = null,
SearchMethod searchTypeLookupKey = SearchMethod.Contains,
			string searchValueLookupKey = null,
SearchMethod searchTypeLookupValue = SearchMethod.Contains,
			string searchValueLookupValue = null,
SearchMethod searchTypeStatus = SearchMethod.Contains,
			string searchValueStatus = null,
SearchMethod searchTypeCreatedBy = SearchMethod.Contains,
			string searchValueCreatedBy = null,
SearchMethod searchTypeLastModifiedBy = SearchMethod.Contains,
			string searchValueLastModifiedBy = null,

						
			string sortBy = null,
			string sortByDirection = null, 
			int maxNumberOfResults = 100)
        {
			var search = new Search();

			if (sortBy != null)
			{
				search.AddSort(sortBy, sortByDirection);
			}

            bool foundOneNonNullSearchValue = false;

			if (String.IsNullOrWhiteSpace(searchValueLookupType) == false)
{
    foundOneNonNullSearchValue = true;
    search.AddArgument(
        "LookupType", searchTypeLookupType, searchValueLookupType);
}
if (String.IsNullOrWhiteSpace(searchValueLookupKey) == false)
{
    foundOneNonNullSearchValue = true;
    search.AddArgument(
        "LookupKey", searchTypeLookupKey, searchValueLookupKey);
}
if (String.IsNullOrWhiteSpace(searchValueLookupValue) == false)
{
    foundOneNonNullSearchValue = true;
    search.AddArgument(
        "LookupValue", searchTypeLookupValue, searchValueLookupValue);
}
if (String.IsNullOrWhiteSpace(searchValueStatus) == false)
{
    foundOneNonNullSearchValue = true;
    search.AddArgument(
        "Status", searchTypeStatus, searchValueStatus);
}
if (String.IsNullOrWhiteSpace(searchValueCreatedBy) == false)
{
    foundOneNonNullSearchValue = true;
    search.AddArgument(
        "CreatedBy", searchTypeCreatedBy, searchValueCreatedBy);
}
if (String.IsNullOrWhiteSpace(searchValueLastModifiedBy) == false)
{
    foundOneNonNullSearchValue = true;
    search.AddArgument(
        "LastModifiedBy", searchTypeLastModifiedBy, searchValueLastModifiedBy);
}

			

            var returnValues = new List<Benday.EasyAuthDemo.Api.DomainModels.Lookup>();

            if (foundOneNonNullSearchValue == true)
            {
                search.MaxNumberOfResults = maxNumberOfResults;

				var results = _Repository.Search(search);
                var entityResults = results.Results;

                _Adapter.Adapt(entityResults, returnValues);
            }

            return returnValues;
        }

		public IList<Benday.EasyAuthDemo.Api.DomainModels.Lookup> Search(Search search)
        {
            var returnValues = new List<Benday.EasyAuthDemo.Api.DomainModels.Lookup>();

            if (search == null || 
                search.Arguments == null ||
                search.Arguments.Count == 0 ||
                search.MaxNumberOfResults == 0)
            {
                return returnValues;
            }
            else
            {
			    var results = _Repository.Search(search);
                var entityResults = results.Results;

                _Adapter.Adapt(entityResults, returnValues);
            }
            
            return returnValues;
        }

		public IList<Lookup> GetAllByType(string lookupType)
        {
            var entityResults = _Repository.GetAllByType(lookupType);

            var returnValues = new List<Lookup>();

            _Adapter.Adapt(entityResults, returnValues);

            return returnValues;
        }
    }
}

