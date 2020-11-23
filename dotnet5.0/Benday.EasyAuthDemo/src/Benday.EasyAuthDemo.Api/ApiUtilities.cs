using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Benday.EasyAuthDemo.Api
{
    public static class ApiUtilities
    {
        public static void ThrowValidationException(object invalidItem, string message)
        {
            throw new InvalidObjectException(message);
        }

        public static void ThrowUnknownObjectException(string unknownItemType, int unknownId)
        {
            throw new UnknownObjectException(
                $"Could not locate an '{unknownItemType}' item with an id of '{unknownId}'."
                );
        }

        internal static string SafeToString(string value, string returnThisIfNull)
        {
            if (String.IsNullOrWhiteSpace(value) == false)
            {
                return value;
            }
            else
            {
                return returnThisIfNull;
            }
        }
    }
}
