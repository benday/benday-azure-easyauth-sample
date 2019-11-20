using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Benday.EasyAuthDemo.Api
{
    public static class ExtensionMethods
    {
        public static string SafeToString(this string value)
        {
            if (value == null)
            {
                return String.Empty;
            }
            else
            {
                return value;
            }
        }

        public static string SafeToString(this string value, string defaultValue)
        {
            if (value == null)
            {
                return defaultValue;
            }
            else
            {
                return value;
            }
        }

        public static int SafeToInt32(this string value, int defaultValue)
        {
            var valueAsString = value.SafeToString();

            if (value == String.Empty)
            {
                return defaultValue;
            }
            else
            {
                int returnValue = defaultValue;

                Int32.TryParse(valueAsString, out returnValue);

                return returnValue;
            }
        }

        public static bool IsNullOrWhitespace(this string value)
        {
            return String.IsNullOrWhiteSpace(value);
        }
    }
}
