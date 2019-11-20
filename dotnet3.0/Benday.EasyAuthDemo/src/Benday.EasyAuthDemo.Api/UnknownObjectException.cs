using System;
using System.Runtime.Serialization;

namespace Benday.EasyAuthDemo.Api
{
    /// <summary>
    /// A data modificiation operation was requested for an item id that does not exist.
    /// </summary>
    public class UnknownObjectException : Exception
    {
        public UnknownObjectException() { }
        public UnknownObjectException(string message) : base(message) { }
        public UnknownObjectException(int id) : 
            base(String.Format("Unknown id '{0}'", id))
        {

        }
    }
}
