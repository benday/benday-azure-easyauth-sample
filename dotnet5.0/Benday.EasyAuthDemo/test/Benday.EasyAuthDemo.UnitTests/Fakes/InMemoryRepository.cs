using Benday.EasyAuthDemo.Api;
using Benday.EasyAuthDemo.Api.DataAccess.Entities;
using Benday.EfCore.SqlServer;
using System;
using System.Collections.Generic;
using System.Linq;
using Benday.Common;

namespace Benday.EasyAuthDemo.UnitTests.Fakes
{
    public class InMemoryRepository<T> : ISearchableRepository<T> where T : IInt32Identity
    {
        private int _CurrentIdentityValue = 0;

        public InMemoryRepository()
        {
            Items = new List<T>();
        }

        public List<T> Items
        {
            get;
            set;
        }

        private bool _WasGetAllCalled;
        public bool WasGetAllCalled
        {
            get { return _WasGetAllCalled; }
        }


        public IList<T> GetAll()
        {
            _WasGetAllCalled = true;

            return Items;
        }

        public IList<T> GetAll(int maxNumberOfResults, bool noIncludes)
        {
            _WasGetAllCalled = true;

            return Items;
        }

        private bool _WasGetByIdCalled;
        public bool WasGetByIdCalled
        {
            get { return _WasGetByIdCalled; }
        }


        public T GetById(int id)
        {
            _WasGetByIdCalled = true;

            return (from temp in Items
                    where temp.Id == id
                    select temp).FirstOrDefault();
        }

        private bool _WasSaveCalled;
        public bool WasSaveCalled
        {
            get { return _WasSaveCalled; }
        }


        public void Save(T saveThis)
        {
            _WasSaveCalled = true;

            if (saveThis == null)
            {
                throw new ArgumentNullException("saveThis", "Argument cannot be null.");
            }

            if (saveThis.Id == 0)
            {
                // assign new identity value
                saveThis.Id = GetNextIdValue();
            }

            if (Items.Contains(saveThis) == false)
            {
                Items.Add(saveThis);
            }

            OnSave(saveThis);

            SaveAttributes(saveThis);
        }

        protected virtual void OnSave(T saveThis)
        {

        }

        private void SaveAttributes(T saveThis)
        {
            if (saveThis is IAttributedEntity saveThisAsAttributed)
            {
                foreach (var item in saveThisAsAttributed.GetAttributes())
                {
                    AttributeRepository.Save(item);
                }
            }
        }

        private InMemoryRepository<EntityBase> _AttributeRepository;

        public InMemoryRepository<EntityBase> AttributeRepository
        {
            get
            {
                if (_AttributeRepository == null)
                {
                    _AttributeRepository = new InMemoryRepository<EntityBase>();
                }

                return _AttributeRepository;
            }
        }

        private bool _WasDeleteByIdCalled;
        public bool WasDeleteByIdCalled
        {
            get { return _WasDeleteByIdCalled; }
        }

        public void Delete(T deleteThis)
        {
            _WasDeleteByIdCalled = true;

            if (deleteThis == null)
            {
                throw new ArgumentNullException("deleteThis", "Argument cannot be null.");
            }

            if (Items.Contains(deleteThis) == true)
            {
                Items.Remove(deleteThis);
            }
        }

        protected int GetNextIdValue()
        {
            return ++_CurrentIdentityValue;
        }

        public void ResetMethodCallTrackers()
        {
            _WasDeleteByIdCalled = false;
            _WasGetAllCalled = false;
            _WasGetByIdCalled = false;
            _WasSaveCalled = false;
        }

        public SearchResult<T> Search(Search search)
        {
            throw new NotImplementedException();
        }
    }
}
