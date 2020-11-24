using System;

namespace Benday.EasyAuthDemo.Api
{
    /// <summary>
    /// Validation on an object instance failed.
    /// </summary>
    public class InvalidObjectException : Exception
    {
        public InvalidObjectException() { }
        public InvalidObjectException(string message) : base(message) { }
    }
}
