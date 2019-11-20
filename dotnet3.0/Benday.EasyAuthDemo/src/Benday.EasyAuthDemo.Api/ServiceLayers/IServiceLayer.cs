using System;
using System.Collections.Generic;
using System.Linq;
using Benday.Common;

namespace Benday.EasyAuthDemo.Api.ServiceLayers
{
    public interface IServiceLayer<T>
    {
        IList<T> GetAll(int maxNumberOfResults = 100);

        T GetById(int id);

        void Save(T saveThis);

        void DeleteById(int id);

		IList<T> Search(Search search);
    }
}
